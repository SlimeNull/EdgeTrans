using System.Text.Json.Serialization;

namespace EdgeTrans
{
    public static partial class Trans
    {
        internal class Translation
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }

            [JsonPropertyName("to")]
            public string To { get; set; }
        }
    }
}