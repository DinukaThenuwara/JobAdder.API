using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobAdder.Data.Models;
using JobAdderApi.Lib.Data.Models;
using JobAdderApi.Lib.Data.Services;
using Moq;
using NUnit.Framework;

namespace JobAdder.Data.Test
{
    [TestFixture]
    public class CandidateServiceTest
    {
        private readonly Mock<IJobAdderGateway> mockJobAdderGateway;
        private readonly ICandidateService CandidateService;


        public CandidateServiceTest()
        {
            mockJobAdderGateway = new Mock<IJobAdderGateway>();
            CandidateService = new CandidateService(mockJobAdderGateway.Object);
        }        

        [Test]
        public async Task GivenCandidatesList_WhenGetBestMachingCandidate_ThenShouldReturnMostWeightedSkilsOne()
        {

            var candiates = new List<Candidate> {
                new Candidate{
                    CandidateId=1,
                    Name ="Test-name",
                    SkillTags= ".net,javascript,java",
                },
                new Candidate{
                    CandidateId=2,
                    Name ="Test-name-2",
                    SkillTags= "java,javascript,.net",
                }, new Candidate{
                    CandidateId=3,
                    Name ="Test-name-3",
                    SkillTags= "python,sql,oracle",
                }
            };

            mockJobAdderGateway.Setup(x => x.GetCandidates()).Returns(Task.FromResult(candiates));
            var request = new CandidateRequest
            {
                JobId = 10,
                SkillTags = new List<string> {
                    ".net", "javascript"
                },
                WeightedSkills = new Dictionary<string, int> {
                    { ".net", 100 },
                    {"javascript", 50}
                }
            };

            var actualCadidates = await CandidateService.GetBestCandidates(request);
            var expectedCandidate = candiates.First(x => x.CandidateId == 1);

            mockJobAdderGateway.Verify(x => x.GetCandidates(), Times.AtLeastOnce());

            Assert.AreEqual(1, actualCadidates.Count);
            Assert.AreEqual(expectedCandidate, actualCadidates.First());

        }

        [Test]
        public async Task GivenCandidatesList_WhenGetBestMachingCandidate_ThenShouldReturnEmptyListWhenThereIsNoMatchingCandidate()
        {

            var candiates = new List<Candidate> {
                new Candidate{
                    CandidateId=1,
                    Name ="Test-name",
                    SkillTags= ".net,javascript,java",
                },
                new Candidate{
                    CandidateId=2,
                    Name ="Test-name-2",
                    SkillTags= "java,javascript,.net",
                }, new Candidate{
                    CandidateId=3,
                    Name ="Test-name-3",
                    SkillTags= "python,sql,oracle",
                }
            };

            mockJobAdderGateway.Setup(x => x.GetCandidates()).Returns(Task.FromResult(candiates));
            var request = new CandidateRequest
            {
                JobId = 10,
                SkillTags = new List<string> {
                    "c++", "oop"
                },
                WeightedSkills = new Dictionary<string, int> {
                    { "c++", 100 },
                    {"oop", 50}
                }
            };

            var actualCadidates = await CandidateService.GetBestCandidates(request);
            var expectedCandidate = candiates.First(x => x.CandidateId == 1);

            mockJobAdderGateway.Verify(x => x.GetCandidates(), Times.AtLeastOnce());

            Assert.AreEqual(0, actualCadidates.Count);
        }


        [Test]
        public async Task GivenCandidatesList_WhenGetBestMachingCandidate_ThenShouldSkipDuplicatedSkillsReturnMostWeightedSkilsOne()
        {

            var candiates = new List<Candidate> {
                new Candidate{
                    CandidateId=1,
                    Name ="Test-name",
                    SkillTags= ".net,javascript",
                },
                new Candidate{
                    CandidateId=2,
                    Name ="Test-name-2",
                    SkillTags= ".net,java,javascript,.net,.net,javascript",
                }, new Candidate{
                    CandidateId=3,
                    Name ="Test-name-3",
                    SkillTags= "python,sql,oracle",
                }
            };


            mockJobAdderGateway.Setup(x => x.GetCandidates()).Returns(Task.FromResult(candiates));
            var request = new CandidateRequest
            {
                JobId = 10,
                SkillTags = new List<string> {
                    ".net", "javascript", "javascript",".net"
                },
                WeightedSkills = new Dictionary<string, int> {
                    { ".net", 100 },
                    {"javascript", 50}
                }
            };

            var actualCadidates = await CandidateService.GetBestCandidates(request);
            var expectedCandidate = candiates.First(x => x.CandidateId == 1);

            mockJobAdderGateway.Verify(x => x.GetCandidates(), Times.AtLeastOnce());

            Assert.AreEqual(1, actualCadidates.Count);
            Assert.AreEqual(expectedCandidate, actualCadidates.First());

        }

        [Test]
        public async Task GivenCandidatesList_WhenGetBestMachingCandidate_ThenShouldSkipDuplicatedSkillsReturnMostWeightedSkilsBasedOnPoints()
        {

            var candiates = new List<Candidate> {
                new Candidate{
                    CandidateId=1,
                    Name ="Test-name",
                    SkillTags= ".net",
                },
                new Candidate{
                    CandidateId=2,
                    Name ="Test-name-2",
                    SkillTags= "java,.net,javascript,pyton,agile,sql",
                }, new Candidate{
                    CandidateId=3,
                    Name ="Test-name-3",
                    SkillTags= "python,sql,oracle",
                }
            };


            mockJobAdderGateway.Setup(x => x.GetCandidates()).Returns(Task.FromResult(candiates));
            var request = new CandidateRequest
            {
                JobId = 10,
                SkillTags = new List<string> {
                    ".net", "javascript", "pyton", "agile", "sql"
                },
                WeightedSkills = new Dictionary<string, int> {
                    { ".net", 140 },
                    {"javascript", 90},
                    {"pyton", 73},
                    {"agile", 65},
                    {"sql", 60}
                }
            };

            var actualCadidates = await CandidateService.GetBestCandidates(request);
            var expectedCandidate = candiates.First(x => x.CandidateId == 2);

            mockJobAdderGateway.Verify(x => x.GetCandidates(), Times.AtLeastOnce());

            Assert.AreEqual(1, actualCadidates.Count);
            Assert.AreEqual(expectedCandidate, actualCadidates.First());

        }

        [Theory]
        public async Task GivenCandidatesList_WhenGetBestMachingCandidate_ThenThrowExceptionWhenCannotConnectExternalAPI()
        {

            var candiates = new List<Candidate> {
                new Candidate{
                    CandidateId=1,
                    Name ="Test-name",
                    SkillTags= ".net,javascript,java",
                },
                new Candidate{
                    CandidateId=2,
                    Name ="Test-name-2",
                    SkillTags= "java,javascript,.net",
                }, new Candidate{
                    CandidateId=3,
                    Name ="Test-name-3",
                    SkillTags= "python,sql,oracle",
                }
            };

            mockJobAdderGateway.Setup(x => x.GetCandidates()).Throws(new Exception("JobAdder GetCandidates API failed..!"));
            var request = new CandidateRequest
            {
                JobId = 10,
                SkillTags = new List<string> {
                    ".net", "javascript"
                },
                WeightedSkills = new Dictionary<string, int> {
                    { ".net", 100 },
                    {"javascript", 50}
                }
            };


            var ex = Assert.ThrowsAsync<Exception>(async () => { var result = await CandidateService.GetBestCandidates(request); });

            mockJobAdderGateway.Verify(x => x.GetCandidates());

            Assert.That(ex.Message, Is.EqualTo("JobAdder GetCandidates API failed..!"));

        }
    }
}