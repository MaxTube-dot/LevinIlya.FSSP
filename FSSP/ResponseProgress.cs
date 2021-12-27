namespace FSSP
{
    public class ResponseProgress
    {
        public string status { get; set; }
        public int code { get; set; }
        public string exception { get; set; }
        public InfoProgress response { get; set; }
    }

    public class InfoProgress
    {
        public int status { get; set; }
        public string progress { get; set; }
    }


}
