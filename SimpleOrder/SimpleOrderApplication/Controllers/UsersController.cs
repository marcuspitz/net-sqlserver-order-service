using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleOrder.Application.Services.Interfaces;
using SimpleOrder.Application.ViewModels;
using System.Threading.Tasks;

namespace SimpleOrder.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;
        private readonly IUserAppService _userService;

        public UsersController(ILogger<PingController> logger, IUserAppService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]UserFilterQueryViewModel filters)
        {
            _logger.LogDebug("Getting users");
            return Ok(_userService.GetUser(filters));
        }
    }
}
