using System;
using System.Linq;
using System.Threading.Tasks;
using dg.Models;
using Flurl;
using Flurl.Http;
using Microsoft.AspNet.Mvc;

namespace dg.Controllers
{
    [Route("api/[controller]")]
    public class CatFactsController :Controller
    {
        // GET: api/catfacts
        [HttpGet]
        public async Task<string> Get()
        {
            try
            {
                var facts = await "http://catfacts-api.appspot.com"
                    .AppendPathSegment("api/facts")
                    .GetJsonAsync<Fact>();

                return facts.facts.FirstOrDefault();
            }
            catch (Exception)
            {

                return "meow";
            }            
        }
    }
}
