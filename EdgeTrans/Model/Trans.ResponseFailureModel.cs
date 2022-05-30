using System.Text.Json.Serialization;

namespace EdgeTrans
{
    public static partial class Trans
    {
        internal class ResponseFailureModel
        {
            [JsonPropertyName("error")]
            public Error Error { get; set; }
        }
    }
}