using SimpleOrder.Application.Services.Interfaces;
using SimpleOrder.Application.ViewModels;
using SimpleOrder.Infra.Data.Models;
using SimpleOrder.Infra.Data.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleOrder.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _repository;

        public ProductAppService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductViewModel> Add(ProductInsertViewModel product)
        {
            var model = await _repository.Add(product.Name, product.Description, product.Price);
            return ConverToView(model);
        }

        public async Task<ProductViewModel> Get(string id)
        {
            var model = await _repository.Get(id);
            return ConverToView(model);
        }

        public async Task<ProductViewModel> Update(ProductUpdateViewModel product)
        {
            var model = await _repository.Update(product.Id, product.Name, product.Description, product.Price);
            return ConverToView(model);
        }

        public async Task<IEnumerable<ProductViewModel>> ListAll(ProductFilterQueryViewModel filters)
        {
            var models = await _repository.ListAll(filters.Name, filters.Description, filters.StartDate, filters.EndDate);
            return models.Select(m => ConverToView(m));
        }

        private ProductViewModel ConverToView(Product model)
        {
            if (model == null)
                return null;
            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CreationDate = model.CreationDate
            };
        }
    }
}
