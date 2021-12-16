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

        public Task<List<Job>> GetAllJobs()
        {
            throw new NotImplementedException();
        }
    }
}
