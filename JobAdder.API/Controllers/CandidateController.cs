using JobAdder.Data.Models;
using JobAdderApi.Lib.Data.Models;
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
    [RoutePrefix("api/candidate")]
    public class CandidateController : ApiController
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [Route("bestcandidate")]
        [HttpPost]
        public async Task<CandidateResponse> GetMostQualifiedCandidate(CandidateRequest request)
        {
            try
            {
                var candidate = await _candidateService.GetBestCandidates(request);
                return new CandidateResponse { Candidates = candidate };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
