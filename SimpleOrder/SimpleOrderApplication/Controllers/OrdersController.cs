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
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;
        private readonly IOrderAppService _service;

        public OrdersController(ILogger<PingController> logger, IOrderAppService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            _logger.LogDebug("GET all orders");
            var result = await _service.ListAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderInsertViewModel order)
        {
            _logger.LogDebug("INSERT order");
            var result = await _service.Add(order);
            return Ok(result);
        }        

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _logger.LogDebug("GET order");
            var model = await _service.Get(id);
            return Ok(model);
        }
    }
}
