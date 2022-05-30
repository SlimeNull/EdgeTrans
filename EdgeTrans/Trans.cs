using System.Collections.Specialized;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Web;

namespace EdgeTrans
{
    public static partial class Trans
    {
        public static HttpClient client = new HttpClient();
        
        public static async Task<TransResult[]> GoAsync(string[] texts, CultureInfo to, CultureInfo? from)            // 翻译一堆句子
        {
            string authToken = await client.GetStringAsync(UriHelper.AuthGet);
            string authHeaderValue = $"Bearer {authToken}";

            Dictionary<string, string> querys = new Dictionary<string, string>();
            querys["api-version"] = "3.0";
            querys["to"] = to.Name;

            if (from != null)
                querys["from"] = from.Name;

            string queryStr = string.Join('&', querys.Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value)}"));           // 拼接查询参数

            Uri transUri = new UriBuilder(UriHelper.TranslateGet)
            {
                Query = queryStr
            }.Uri;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, transUri);                                  // 鉴权
            request.Headers.Add("Authorization", authHeaderValue);

            request.Content = new StringContent(
                JsonSerializer.Serialize(new RequestModel(texts)),
                Encoding.UTF8, MediaTypeNames.Application.Json);                                                             // 把内容扔进去

            using HttpResponseMessage resp = await client.SendAsync(request);
            using Stream respStream = await resp.Content.ReadAsStreamAsync();

#if DEBUG                                                                                                                    // 调试的时候直接打印结果
            string respStr = new StreamReader(respStream).ReadToEnd();
            return new TransResult[] { new TransResult(null, new string[] { respStr }) };
#endif

            JsonDocument jdoc = await JsonDocument.ParseAsync(respStream);
            switch (jdoc.RootElement.ValueKind)
            {
                case JsonValueKind.Array:
                    ResponseSuccessModel succModel = JsonSerializer.Deserialize<ResponseSuccessModel>(jdoc);                              // 不调试的时候正儿八经返回值
                    return succModel
                        .Select(ele => new TransResult(
                            new CultureInfo(ele.DetectedLanguage.Language),
                            ele.Translations
                                .Select(trans => trans.Text)
                                .ToArray()))
                        .ToArray();
                    break;
                case JsonValueKind.Object:
                    ResponseFailureModel failModel = JsonSerializer.Deserialize<ResponseFailureModel>(jdoc);
                    throw new InvalidOperationException($"Error code: {failModel.Error.Code}. Message: {failModel.Error.Message}");
                    break;
                default:
                    throw new Exception();
            }
        }
        public static Task<TransResult[]> GoAsync(string[] texts, CultureInfo to) => GoAsync(texts, to, null);

        public static async Task<TransResult> GoAsync(string text, CultureInfo to, CultureInfo? from) => (await GoAsync(new string[] { text }, to, from))[0];    // 翻译一个句子
        public static Task<TransResult> GoAsync(string text, CultureInfo to) => GoAsync(text, to, null);

        public static TransResult[] Go(string[] texts, CultureInfo to, CultureInfo? from) => GoAsync(texts, to, from).Result;
        public static TransResult[] Go(string[] texts, CultureInfo to) => GoAsync(texts, to, null).Result;

        public static TransResult Go(string text, CultureInfo to, CultureInfo? from) => GoAsync(new string[] { text }, to, from).Result[0];
        public static TransResult Go(string text, CultureInfo to) => GoAsync(new string[] { text }, to, null).Result[0];
    }
}