using JobAdder.Data;
using JobAdder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdderApi.Lib.Data.Services
{
    public class JobService : IJobService
    {
        private readonly IJobAdderGateway _jobAdderGateway;
        public JobService(IJobAdderGateway jobAdderGateway)
        {
            _jobAdderGateway = jobAdderGateway;
        }

        public async Task<List<Job>> GetAllJobs()
        {
            try
            {
                var jobs = await _jobAdderGateway.GetJobs();
                return jobs;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
