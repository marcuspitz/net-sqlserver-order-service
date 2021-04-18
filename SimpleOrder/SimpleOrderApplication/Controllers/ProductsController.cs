using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleOrder.Application.Services.Interfaces;
using SimpleOrder.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimpleOrder.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;
        private readonly IProductAppService _service;

        public ProductsController(ILogger<PingController> logger, IProductAppService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListAll([FromQuery]ProductFilterQueryViewModel filters)
        {
            _logger.LogDebug("GET all products");
            var result = await _service.ListAll(filters);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductInsertViewModel product)
        {
            _logger.LogDebug("INSERT product");
            var result = await _service.Add(product);
            return Ok(result);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update(string id, ProductInsertViewModel product)
        {
            _logger.LogDebug("UPDATE product");
            try
            {
                var model = await _service.Update(new ProductUpdateViewModel()
                {
                    Id = id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                });
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _logger.LogDebug("GET product");
            var model = await _service.Get(id);
            return Ok(model);
        }
    }
}
