using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;
using System.Net;
using TeknorixTest.Dapper;
using TeknorixTest.RequestModel;
using TeknorixTest.ResponseModel;

namespace TeknorixTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IDbConnection _dbContext;
        public JobController(IDbConnection dbConnection)
        {
            _dbContext = dbConnection;


        }
        [Route("CreateJobs")]
        [HttpPost]
        public async Task<IActionResult> createJobs(CreateJobs createJobs)
        {
            try
            {
                if (createJobs.title.Trim() == "")
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter title",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (createJobs.description.Trim() == "")
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter description",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (createJobs.locationId == 0)
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter location id",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (createJobs.departmentId == 0)
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter department id",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (createJobs.closingDate < DateTime.Now)
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter valid closing date",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                var departmentInfo = new Dictionary<int, string>
            {
                { 1, "IT Department" },
                { 2, "HR Department" },
                { 3, "IT Admin"}
            };
                if (!departmentInfo.ContainsKey(createJobs.departmentId))
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter valid department id",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                var locationInfo = new Dictionary<int, string>
            {
                { 1, "Mapusa" },
                { 2, "Panjim" },
                { 3, "Margao"}
            };
                if (!locationInfo.ContainsKey(createJobs.locationId))
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter valid location id",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }

                var para = new DynamicParameters();
                para.Add("@title", createJobs.title);
                para.Add("@description", createJobs.description);
                para.Add("@locationId", createJobs.locationId);
                para.Add("@closingDate", createJobs.closingDate);
                para.Add("@departmentId", createJobs.departmentId);

                var data = _dbContext.Query<dynamic>("usp_create_job", para, commandType: CommandType.StoredProcedure);
                var dbResult = data.FirstOrDefault();
                var jobResult = new Result
                {
                    result = Convert.ToBoolean(dbResult.result),
                    resultMessage = dbResult.resultMessage,
                    details = new { jobId = Convert.ToInt32(dbResult.jobId) },
                    status = HttpStatusCode.OK
                };
                return Ok(jobResult);

            }
            catch (Exception ex)
            {
                var data = new Result
                {
                    result = false,
                    resultMessage = ex.Message,
                    details = null,
                    status = HttpStatusCode.InternalServerError
                };
                return Ok(data);
            }

        }


        [Route("UpdateJobs")]
        [HttpPut]
        public async Task<IActionResult> updateJobs(UpdateJobs updateJobs)
        {
            try
            {
                if (updateJobs.jobId == 0)
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter job id",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (updateJobs.title.Trim() == "")
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter title",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (updateJobs.description.Trim() == "")
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter description",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (updateJobs.locationId == 0)
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter location id",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (updateJobs.departmentId == 0)
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter department id",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                if (updateJobs.closingDate < DateTime.Now)
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter valid closing date",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }
                var departmentInfo = new Dictionary<int, string>
                {
                    { 1, "IT Department" },
                    { 2, "HR Department" },
                    { 3, "IT Admin"}
                };
                if (!departmentInfo.ContainsKey(updateJobs.departmentId))
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter valid department id",
                        details = null,
                        status = HttpStatusCode.Created,
                    };
                    return Ok(result);
                }
                var locationInfo = new Dictionary<int, string>
                {
                    { 1, "Mapusa" },
                    { 2, "Panjim" },
                    { 3, "Margao"}
                };
                if (!locationInfo.ContainsKey(updateJobs.locationId))
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "Enter valid location id",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(result);
                }

                var para = new DynamicParameters();
                para.Add("@jobId", updateJobs.jobId);
                para.Add("@title", updateJobs.title);
                para.Add("@description", updateJobs.description);
                para.Add("@locationId", updateJobs.locationId);
                para.Add("@closingDate", updateJobs.closingDate);
                para.Add("@departmentId", updateJobs.departmentId);

                var data = _dbContext.Query<dynamic>("usp_update_job", para, commandType: CommandType.StoredProcedure);
                var dbResult = data.FirstOrDefault();
                var jobResult = new Result
                {
                    result = Convert.ToBoolean(dbResult.result),
                    resultMessage = dbResult.resultMessage,
                    details = new { jobId = Convert.ToInt32(dbResult.jobId) },
                    status = HttpStatusCode.OK
                };
                return Ok(jobResult);

            }
            catch (Exception ex)
            {
                var data = new Result
                {
                    result = false,
                    resultMessage = ex.Message,
                    details = null,
                    status = HttpStatusCode.InternalServerError
                };
                return Ok(data);
            }

        }

        [Route("JobList")]
        [HttpPost]
        public async Task<IActionResult> jobList(JobList jobList)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(jobList.Q))
                {
                    var inputValidate = new Result()
                    {
                        result = false,
                        resultMessage = "Enter search string",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(inputValidate);
                    
                }

                if (jobList.PageNo == 0)
                {
                    var inputValidate = new Result()
                    {
                        result = false,
                        resultMessage = "Enter page no",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(inputValidate);

                }
                if (jobList.PageSize == 0)
                {
                    var inputValidate = new Result()
                    {
                        result = false,
                        resultMessage = "Enter page size",
                        details = null,
                        status = HttpStatusCode.BadRequest,
                    };
                    return Ok(inputValidate);

                }
                var departmentInfo = new Dictionary<int, string>
                {
                    { 1, "IT Department" },
                    { 2, "HR Department" },
                    { 3, "IT Admin"}
                };
                var locationInfo = new Dictionary<int, string>
                {
                    { 1, "Mapusa" },
                    { 2, "Panjim" },
                    { 3, "Margao"}
                };
                var para = new DynamicParameters();
                para.Add("@q", jobList.Q);
                para.Add("@pageNo", jobList.PageNo);
                para.Add("@pageSize", jobList.PageSize);
                para.Add("@locationId", jobList.LocationId);
                para.Add("@departmentId", jobList.DepartmentId);

                var data = _dbContext.Query<GetJobList>("usp_list_jobs", para, commandType: CommandType.StoredProcedure);
             
                var mappedResult = data.Select(job => new NewGetJobList
                {
                    id = job.id,
                    code = job.code,
                    title = job.title,
                    locationId = job.locationId,
                    location = locationInfo.ContainsKey(job.locationId) ? locationInfo[job.locationId] : "NA",
                    departmentId = job.departmentId,
                    department = departmentInfo.ContainsKey(job.departmentId) ? departmentInfo[job.departmentId] : "NA",
                    postedDate = job.postedDate,
                    closingDate = job.closingDate
                });
                if (mappedResult.Count() > 0)
                {
                    var result = new Result()
                    {
                        result = true,
                        resultMessage = "List fetched successfully",
                        details = mappedResult,
                        status = HttpStatusCode.OK                  
                    };
                    return Ok(result);
                }
                else 
                {
                    var result = new Result()
                    {
                        result = false,
                        resultMessage = "List not found",
                        details = null,
                        status = HttpStatusCode.OK
                    };
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                var errorResult = new Result
                {
                    result = false,
                    resultMessage = ex.Message,
                    details = null,
                    status = HttpStatusCode.InternalServerError
                };

                return Ok(errorResult);
            }

        }
    }
}
