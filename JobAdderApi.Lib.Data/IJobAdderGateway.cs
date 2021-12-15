using JobAdder.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobAdder.Data
{
    interface IJobAdderGateway
    {
        Task<List<Job>> GetJobs();
        Task<List<Candidate>> GetCandidates();
    }
}
