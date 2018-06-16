using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI.Autoregister.Sample.Business;
using Microsoft.AspNetCore.Mvc;

namespace DI.Autoregister.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly FirstBusiness _firstBusiness;

        private readonly SecondBusiness _secondBusiness;
        public ValuesController(FirstBusiness firstBusiness, SecondBusiness secondBusiness)
        {
            _firstBusiness = firstBusiness;
            _secondBusiness = secondBusiness;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{value}")]
        public ActionResult<string> Get(string value)
        {
            return _firstBusiness.GetValueUppercase(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
