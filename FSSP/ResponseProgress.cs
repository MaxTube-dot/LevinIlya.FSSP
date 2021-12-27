using System.Text.Json.Serialization;

namespace FSSP
{
    public class ResponseProgress
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("exception")]
        public string Exception { get; set; }

        [JsonPropertyName("response")]
        public InfoProgress Response { get; set; }
    }

    public class InfoProgress
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("progress")]
        public string Progress { get; set; }
    }


}
