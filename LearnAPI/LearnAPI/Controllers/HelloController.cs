using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string SayHello()
        {
            return "Hello World";
        }

        [HttpGet("get-object")]
        public IActionResult getObject()
        {
            var obj =  new
            {
                Id = Guid.NewGuid(),
            };

            return Ok(obj);
        }

        [HttpGet("get-array-of-object")]
        public IActionResult getArrayOfObject()
        {
            var array = new List<Object>
            {
                new { Id = Guid.NewGuid()},
                new { Id = Guid.NewGuid()},
                new { Id = Guid.NewGuid()}
            };

            return Ok(array);
        }

        [HttpGet("/name/{name}")]
        public IActionResult getPathVariable(string name)
        {

            return Ok(name);
        }

        [HttpGet("query-param")]
        public IActionResult getQueryParam([FromQuery] string name)
        {

            return Ok(name);
        }

    }
}
