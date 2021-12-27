using System.Text.Json.Serialization;

namespace FSSP
{
    public class ResponseTask
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("exception")]
        public string Exception { get; set; }
        [JsonPropertyName("response")]
        public InfoTask Response { get; set; }
    }

    public class InfoTask
    {
        [JsonPropertyName("task")]
        public string Task { get; set; }
    }



}
