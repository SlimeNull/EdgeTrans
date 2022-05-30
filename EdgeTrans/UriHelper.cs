namespace EdgeTrans
{
    internal static class UriHelper
    {
        public const string AuthGet = "https://edge.microsoft.com/translate/auth";
        /// <summary>
        /// 翻译接口
        /// 
        /// 参数:
        ///   from: 语言代码  (可空)
        ///   to:   语言代码  (zh-CHS)
        ///   api-version: 版本号 (3.0)
        ///   includeSentenceLength: true
        /// </summary>
        public const string TranslateGet = "https://api.cognitive.microsofttranslator.com/translate";
    }
}