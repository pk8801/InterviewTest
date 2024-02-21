using System.Net;

namespace TeknorixTest.ResponseModel
{
    public class Result
    {
        public bool result { get; set; }
        public string resultMessage { get; set; }
        public dynamic details { get; set; }
        public HttpStatusCode status {get; set; }
    }
}
