using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SimpleOrder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {

        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("API is running properly");
            return Ok(new {
                success = true,
                message = "API is running properly"
            });
        }
    }
}
