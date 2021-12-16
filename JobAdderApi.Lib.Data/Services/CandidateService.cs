using JobAdder.Data;
using JobAdder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdderApi.Lib.Data.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IJobAdderGateway _jobAdderGateway;

        public CandidateService(IJobAdderGateway jobAdderGateway)
        {
            _jobAdderGateway = jobAdderGateway;
        }

        public Task<List<Candidate>> GetBestCandidates()
        {
            throw new NotImplementedException();
        }

        public Task<List<Candidate>> GetMatchingCandidates()
        {
            throw new NotImplementedException();
        }
    }
}
