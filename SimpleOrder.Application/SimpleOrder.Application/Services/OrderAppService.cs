using SimpleOrder.Application.Services.Interfaces;
using SimpleOrder.Application.ViewModels;
using SimpleOrder.Infra.Data.Models;
using SimpleOrder.Infra.Data.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleOrder.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _repository;

        public OrderAppService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderViewModel> Add(OrderInsertViewModel order)
        {
            var model = await _repository.Add(order.UserId, order.Products.Select(p => new OrderProduct(p.ProductId, p.Price, p.Quantity)).ToList());
            return ConverToView(model);
        }

        public async Task<OrderViewModel> Get(string id)
        {
            var model = await _repository.Get(id);
            return ConverToView(model);
        }


        public async Task<IEnumerable<OrderViewModel>> ListAll()
        {
            var models = await _repository.ListAll();
            return models.Select(m => ConverToView(m));
        }

        private OrderViewModel ConverToView(Order model)
        {
            if (model == null)
                return null;
            return new OrderViewModel()
            {
                Id = model.Id,
                UserId = model.UserId,
                Products = model.Products.Select(p => new OrderProductViewModel()
                {
                    ProductId = p.ProductId,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToList()
            };
        }
    }
}
