using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeknorixTest.ResponseModel;

namespace TeknorixTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [Route("GetLocationInfo")]
        [HttpGet]
        public IActionResult getLocationInfo()
        {
            var locationInfo = new Dictionary<int, string>
            {
                { 1, "Mapusa" },
                { 2, "Panjim" },
                { 3, "Margao"}
            };

            var result = new Result()
            {
                result = true,
                resultMessage = "List fetched successfully",
                details = locationInfo,
                status = HttpStatusCode.OK
            };
            return Ok(result);
        }
    }
}
