using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domains.Model;
using Domains.IRespositories;


namespace WebAPIDemo.Controllers.v2
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v2/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITestTableRepository _testTableRep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testTableRepository"></param>
        public ValuesController(ITestTableRepository testTableRepository)
        {
            _testTableRep = testTableRepository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _testTableRep.Entities.Select(x => x.Id.ToString() + "->" + x.Address + "->" + x.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            Console.WriteLine(value);
            Console.WriteLine("new test value.");
            Console.WriteLine("new test value.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
