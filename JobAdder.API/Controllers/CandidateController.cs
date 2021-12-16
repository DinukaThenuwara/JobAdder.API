using JobAdderApi.Lib.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobAdder.API.Controllers
{
    public class CandidateController : ApiController
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
