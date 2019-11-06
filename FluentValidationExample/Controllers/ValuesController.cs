using System.Collections.Generic;
using FluentValidationExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "value1", "value2" };
        }

        [HttpPost("Test")]
        public ActionResult<string> Post([FromBody] StudentViewModel model)
        {
            return $"Student {model.Name} was added";
        }
    }
}
