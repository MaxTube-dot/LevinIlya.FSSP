namespace FSSP
{
    public class ResponseTask
    {
        public string status { get; set; }
        public int code { get; set; }
        public string exception { get; set; }
        public InfoPhysical response { get; set; }
    }

    public class InfoPhysical
    {
        public string task { get; set; }
    }



}
