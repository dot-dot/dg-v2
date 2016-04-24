using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dg.Models;
using Flurl;
using Flurl.Http;
using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Mvc;

namespace dg.Controllers
{    
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class CatFactsController :Controller
    {

        // GET: api/catfacts
        [HttpGet]
        [RouteAttribute("{count?}")]
        public async Task<IEnumerable<string>> Get(int count = 1)
        {
            try
            {
                var facts = await "http://catfacts-api.appspot.com"
                    .AppendPathSegment("api/facts")
                    .SetQueryParams(new 
                {
                    number = count
                })
            .GetJsonAsync<Fact>();

                return facts.facts;
            }
            catch (Exception)
            {

                return new [] { "meow"};
            }            
        }
    }
}
