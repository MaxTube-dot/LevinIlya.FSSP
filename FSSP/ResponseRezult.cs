namespace FSSP
{
    public class ResponseRezult
    {
        public string status { get; set; }
        public int code { get; set; }
        public string exception { get; set; }
        public RezultInfo1 response { get; set; }
    }
    public class RezultInfo1
    {
        public int status { get; set; }
        public object task_start { get; set; }
        public InfoRezultInfo2[] result { get; set; }
    }

    public class InfoRezultInfo2
    {
        public int status { get; set; }
        public User[] result { get; set; }
    }


    public class User
    {
        public string name { get; set; }
        public string exe_production { get; set; }
        public string details { get; set; }
        public string subject { get; set; }
        public int department { get; set; }
        public string bailiff { get; set; }
        public string ip_end { get; set; }
    }


}
