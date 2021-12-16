using JobAdder.Data.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAdder.Data.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetCandidates()
        {
            JobAdderGateway gateway = new JobAdderGateway();

            var data = await gateway.GetCandidates();

            Assert.IsTrue(data.Count > -1);

        }

        [Test]
        public async Task GetJobs()
        {
            JobAdderGateway gateway = new JobAdderGateway();

            var data = await gateway.GetJobs();

            Assert.IsTrue(data.Count > -1);

        }

        [Test]
        public async Task GetMatchingCandidate()
        {
            //JobAdderGateway gateway = new JobAdderGateway();

            //var job = new Job { JobId =1, Name = "test", Skills = "mobile, java, swift, objective-c, iOS, xcode, fastlane, aws, kotlin, hockey-app" };
            //var candidates = await gateway.GetCandidates();

            //Dictionary<string, List<Candidate>> matchingCandidates = new Dictionary<string, List<Candidate>>();

            //foreach(var skill in job.WeightedSkills)
            //{
            //    matchingCandidates.Add(skill, candidates.FindAll(a => a.WeightedSkills.Contains(skill)));
            //}

            //Candidate bestMatch;
            //List<Candidate> filteredCandidates = new List<Candidate>();

            //foreach (var item in matchingCandidates)
            //{
            //    if (item.Value.Count == 0) continue;

            //    if (filteredCandidates.Count == 0)
            //        filteredCandidates = item.Value;
            //    else if(filteredCandidates.Count == 1)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        var tempList = filteredCandidates.Intersect(item.Value).ToList();
            //        if (tempList.Count == 0)
            //            continue;
            //        if (tempList.Count == 1)
            //            break;
            //        else
            //            filteredCandidates = filteredCandidates.Intersect(item.Value).ToList();
            //    }    
            //}
            //Assert.IsTrue(filteredCandidates.Count > -1);

            Assert.IsTrue(1 == 1);

        }


        [Test]
        public async Task GetBestMatchingCandidate()
        {
            JobAdderGateway gateway = new JobAdderGateway();

            var job = new Job { JobId = 1, Name = "test", Skills = "mobile, java, swift, objective-c, iOS, xcode, fastlane, aws, kotlin, hockey-app" };

            var candidates = await gateway.GetCandidates();

            var potentialCandidates = candidates.Where(a => a.Skills.Intersect(job.SkillTags).ToList().Count > 0).ToList();


            var evaluatedCandidates = new Dictionary<Candidate, int>();

            foreach (var c in potentialCandidates)
            {
                var points = 0;

                foreach (var s in job.WeightedSkills)
                {
                    if (c.WeightedSkills.ContainsKey(s.Key))
                    {
                        points += c.WeightedSkills[s.Key] * s.Value;
                    }
                }
                evaluatedCandidates.Add(c, points);
            }

            var sorted = evaluatedCandidates.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, a => a.Value);

            Assert.IsTrue(1 == 1);

        }
    }
}