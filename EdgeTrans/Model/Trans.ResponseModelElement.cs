using System.Text.Json.Serialization;

namespace EdgeTrans
{
    public static partial class Trans
    {
        internal class ResponseModelElement
        {
            [JsonPropertyName("detectedLanguage")]
            public Detectedlanguage DetectedLanguage { get; set; }

            [JsonPropertyName("translations")]
            public Translation[] Translations { get; set; }
        }
    }
}