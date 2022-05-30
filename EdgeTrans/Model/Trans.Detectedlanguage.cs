using System.Text.Json.Serialization;

namespace EdgeTrans
{
    public static partial class Trans
    {
        internal class Detectedlanguage
        {
            [JsonPropertyName("language")]
            public string Language { get; set; }

            [JsonPropertyName("score")]
            public float Score { get; set; }
        }
    }
}