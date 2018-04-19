using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domains.Model;
using Domains.IRespositories;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITestTableRepository _testTableRep;

        public ValuesController(ITestTableRepository testTableRepository)
        {
            _testTableRep = testTableRepository;
        }
        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            TestTableEntity tte = new TestTableEntity()
            {
                Id = Guid.NewGuid(),
                Address = "new address",
                Name = "test name",
                Sex = 0
            };
            int a = _testTableRep.Insert(tte);            
           
            return new string[] { a.ToString(), "" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            Console.WriteLine(value);
            Console.WriteLine("new test value.");
            Console.WriteLine("new test value.");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
