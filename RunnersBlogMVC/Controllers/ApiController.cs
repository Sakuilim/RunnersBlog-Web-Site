
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;

namespace RunnersBlogMVC.Controllers
{
    [ApiController]
    [Route("/facts/random")]
    public class ApiController : Controller
    {
        static HttpClient client = new HttpClient();
        // GET: ApiController
        [HttpGet]
        public async Task<IEnumerable<FactData>> GetRandomFacts()
        {
            var client_id = "ce3a64fdb53244489360170e870e9129";
            var client_secret = "205c2a99709c494197216179d45662d3";
            IEnumerable<FactData> body = null;
            HttpResponseMessage response = await client.GetAsync("api.dribbble.com/v2/");
            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsAsync<IEnumerable<FactData>>();
            }
            return body;
        }
        // POST
        //[HttpPost]
        //public async Task<IEnumerable<FactData>> PostRandomFacts()
        //{
        //    FactData fact = new()
        //    {
        //        text = 
        //    };

        //}
    }
}
