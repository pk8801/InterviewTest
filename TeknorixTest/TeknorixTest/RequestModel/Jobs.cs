namespace TeknorixTest.RequestModel
{
    
    public class CreateJobs 
    {
        public string title { get; set; }
        public string description { get; set; }
        public int locationId { get; set; }
        public int departmentId { get; set; }
        public DateTime closingDate { get; set; }
    }

    public class UpdateJobs
    {
        public int jobId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int locationId { get; set; }
        public int departmentId { get; set; }
        public DateTime closingDate { get; set; }
    }
}
