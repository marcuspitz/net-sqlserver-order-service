using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleOrder.Application.Services.Interfaces;
using SimpleOrder.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleOrder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAuthAppService _service;

        public AuthController(ILogger<AuthController> logger, IAuthAppService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost, Route("signin")]
        public async Task<IActionResult> Signin(SigninRequestViewModel request)
        {
            _logger.LogDebug("Signing in");
            var result = await _service.Signin(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost, Route("signup")]
        public async Task<IActionResult> Signup(UserRequestViewModel request)
        {
            _logger.LogDebug("Signing up");
            var result = await _service.Signup(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
