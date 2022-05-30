using System.Text.Json.Serialization;

namespace EdgeTrans
{
    public static partial class Trans
    {
        internal class Error
        {
            /// <summary>
            /// 400021: The API version parameter is not valid. <br/>
            ///  <br/>
            /// 400035: The source language is not valid. <br/>
            /// 400036: The target language is not valid. <br/>
            ///  <br/>
            /// 401000: The request is not authorized because credentials are missing or invalid.
            /// </summary>
            [JsonPropertyName("code")]
            public int Code { get; set; }

            [JsonPropertyName("message")]
            public string Message { get; set; }
        }
    }
}