using JobAdder.Data.Models;
using JobAdderApi.Lib.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JobAdder.API.Controllers
{
    [RoutePrefix("api/job")]
    public class JobController : ApiController
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<JobResponse> GetAllJobs()
        {
            try
            {
                var jobs = await _jobService.GetAllJobs();

                return new JobResponse { Jobs = jobs };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
