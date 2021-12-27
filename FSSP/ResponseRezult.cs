using System.Text.Json.Serialization;

namespace FSSP
{
    public class ResponseRezult
    {
        [JsonPropertyName("status")]
        public string status { get; set; }
        [JsonPropertyName("code")]
        public int code { get; set; }
        [JsonPropertyName("exception")]
        public string exception { get; set; }
        [JsonPropertyName("response")]
        public RezultInfo1 response { get; set; }
    }
    public class RezultInfo1
    {
        [JsonPropertyName("status")]
        public int status { get; set; }
        [JsonPropertyName("task_start")]
        public object task_start { get; set; }
        [JsonPropertyName("result")]
        public InfoRezultInfo2[] result { get; set; }
    }

    public class InfoRezultInfo2
    {
        [JsonPropertyName("status")]
        public int status { get; set; }
        [JsonPropertyName("result")]
        public User[] result { get; set; }
    }


    public class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("exe_production")]
        public string ExeProduction { get; set; }
        [JsonPropertyName("details")]
        public string Details { get; set; }
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        [JsonPropertyName("department")]
        public int Department { get; set; }
        [JsonPropertyName("bailiff")]
        public string Bailiff { get; set; }
        [JsonPropertyName("ip_end")]
        public string IpEnd { get; set; }
    }


}
