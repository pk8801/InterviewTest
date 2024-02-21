using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeknorixTest.ResponseModel;

namespace TeknorixTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDepartmentInfo()
        {
            var departmentInfo = new Dictionary<int, string>
            {
                { 1, "IT Department" },
                { 2, "HR Department" },
                { 3, "IT Admin" }
            };

            var result = new Result()
            {
                result = true,
                resultMessage = "List fetched successfully",
                details = departmentInfo,
                status = HttpStatusCode.OK
            };
            return Ok(result);
        }
    }
}
