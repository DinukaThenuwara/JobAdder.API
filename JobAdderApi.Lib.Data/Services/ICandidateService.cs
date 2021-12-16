using JobAdder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdderApi.Lib.Data.Services
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetBestCandidates();
        Task<List<Candidate>> GetMatchingCandidates();
    }
}
