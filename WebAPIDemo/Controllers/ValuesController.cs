using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domains.Model;
using Domains.IRespositories;
using RedisLib;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using NewRedis=StackExchange.Redis;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITestTableRepository _testTableRep;
        private IConfigurationRoot _config;
        private NewRedis.IDatabase database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testTableRepository"></param>
        public ValuesController(ITestTableRepository testTableRepository, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json");
            _config = builder.Build();
            database = RedisClientSingleton.GetInstance(_config).GetDatabase("Redis_6");
            _testTableRep = testTableRepository;
        }

        /// <summary>
        /// get testTable table's record list 
        /// GET api/values
        /// </summary>
        /// <returns>format json string</returns>
        [HttpGet]
        public string Get()
        {
            return CommonSolution.FormatJson.ConvertJsonString(Newtonsoft.Json.JsonConvert.SerializeObject(_testTableRep.Entities));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [HttpGet("GetList/num")]
        public string GetList(int num)
        {
            return CommonSolution.FormatJson.ConvertJsonString(Newtonsoft.Json.JsonConvert.SerializeObject(_testTableRep.Entities.Take(num)));
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
            database.StringSet("ok", id.ToString());
            Console.WriteLine("id value:" + database.StringGet("ok"));
            return database.StringGet("ok");
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
