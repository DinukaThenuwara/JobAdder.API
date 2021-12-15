using NUnit.Framework;
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
    }
}