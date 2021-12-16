using JobAdder.Data;
using JobAdder.Data.Models;
using JobAdderApi.Lib.Data.Models;
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

        public async Task<List<Candidate>> GetBestCandidates(CandidateRequest request)
        {
            try
            {
                var bestCandidates = new List<Candidate>();
                var candidates = await _jobAdderGateway.GetCandidates();

                var potentialCandidates = candidates.Where(a => a.Skills.Intersect(request.SkillTags).ToList().Count > 0).ToList();

                var evaluatedCandidates = new Dictionary<Candidate, int>();

                foreach (var c in potentialCandidates)
                {
                    var points = 0;

                    foreach (var s in request.WeightedSkills)
                    {
                        if (c.WeightedSkills.ContainsKey(s.Key))
                        {
                            points += c.WeightedSkills[s.Key] * s.Value;
                        }
                    }
                    evaluatedCandidates.Add(c, points);
                }

                if (evaluatedCandidates.Count == 0)
                    return bestCandidates; 

                var sorted = evaluatedCandidates.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, a => a.Value);

                var bestMatch = sorted.ElementAt(0);

                bestCandidates.Add(bestMatch.Key);
                
                return bestCandidates;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<Candidate>> GetMatchingCandidates()
        {
            throw new NotImplementedException();
        }
    }
}
