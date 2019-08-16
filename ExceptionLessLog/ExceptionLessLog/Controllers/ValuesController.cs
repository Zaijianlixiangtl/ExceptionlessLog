using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCard.Framework.LogHelper;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionLessLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;

        public ValuesController(ILogger logger)
        {
            this._logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.Info("你好 ExceptionLess Info ","test");
            try
            {
                object a = null;
                int.Parse(a.ToString());
            }
            catch (Exception ex)
            {
                _logger.Exception(ex);
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
