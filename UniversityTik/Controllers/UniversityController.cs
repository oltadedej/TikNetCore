using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityTik.Controllers
{
    [Route("api/University")]
    [ApiController]
    public class UniversityController : ControllerBase
    {

        #region  Properties
        public readonly ILogger<UniversityController> logger;

        #endregion

        #region Constructor

        public UniversityController(ILogger<UniversityController> _logger)
        {
            this.logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }
        #endregion

        // GET api/<UniversityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            if (id == 2)
            {
                logger.LogInformation($"Id eshte: {id}");

            }
            return "value";
        }





        // GET: api/<UniversityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      

        // POST api/<UniversityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UniversityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UniversityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
