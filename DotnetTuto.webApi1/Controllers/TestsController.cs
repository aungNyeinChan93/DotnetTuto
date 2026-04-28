using DotnetTuto.consoleApp1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTuto.webApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly EffortlessService _service;

        public TestsController(EffortlessService service)
        {
            _service = service;
        }

        [HttpGet("one")]
        public async Task<IActionResult> Encode()
        {
            string secret = "my secrert ";
            var res = _service.Encode(secret);
            return Ok(res);
        }

        [HttpPost("two")]
        public async Task<IActionResult> Decode([FromBody]string str)
        {
            return Ok(_service.Decode(str));
        }
    }
}
