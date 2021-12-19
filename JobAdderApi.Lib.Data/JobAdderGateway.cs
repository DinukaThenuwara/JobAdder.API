using JobAdder.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobAdder.Data
{
    public class JobAdderGateway : IJobAdderGateway
    {
        private readonly Uri _JobAdderAddress;
        public JobAdderGateway()
        {
            var url = ConfigurationManager.AppSettings["JobAdderAPIUrl"];
            _JobAdderAddress = new Uri(url);
        }

        public async Task<List<Candidate>> GetCandidates()
        {
            try
            {

                using (HttpClient client = new HttpClient { BaseAddress = _JobAdderAddress })
                {
                    HttpResponseMessage response = await client.GetAsync("candidates");

                    var responseData = await response.Content.ReadAsAsync<List<Candidate>>();

                    return responseData;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }


        }

        public async Task<List<Job>> GetJobs()
        {
            try
            {
                using (HttpClient client = new HttpClient { BaseAddress = _JobAdderAddress })
                {
                    HttpResponseMessage response = await client.GetAsync("jobs");

                    var responseData = await response.Content.ReadAsAsync<List<Job>>();

                    return responseData;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }
    }
}
