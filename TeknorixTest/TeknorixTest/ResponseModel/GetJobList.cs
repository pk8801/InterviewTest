namespace TeknorixTest.ResponseModel
{
    public class GetJobList
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public int locationId { get; set; }
        public int departmentId { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }
        
    }

    public class NewGetJobList
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public int locationId { get; set; }
        public string location { get; set; }
        public int departmentId { get; set; }
        public string department { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }

    }
}
