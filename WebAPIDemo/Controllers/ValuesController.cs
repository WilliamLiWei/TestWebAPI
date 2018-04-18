using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Domains.Model;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly liweitestContext _liweitestContext;
        private readonly ITestTableService _testTable;

        public ValuesController(liweitestContext context, ITestTableService tt)
        {            
            _liweitestContext = context ?? throw new Exception("Not correct DB context");
            _testTable = tt;
        }
        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {            
            TestTableEntity tt = new TestTableEntity()
            {
                Id = Guid.NewGuid(),
                Name = "william li",
                Address = "jhc"
            };
            _liweitestContext.TestTable.Add(tt);
            _liweitestContext.SaveChanges();
            return new string[] { "value1 sdfsdf", "value2  sdfsf" };
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
