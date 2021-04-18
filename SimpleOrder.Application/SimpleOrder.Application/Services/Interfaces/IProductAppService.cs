using SimpleOrder.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleOrder.Application.Services.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductViewModel> Update(ProductUpdateViewModel product);
        Task<ProductViewModel> Add(ProductInsertViewModel product);
        Task<ProductViewModel> Get(string id);
        Task<IEnumerable<ProductViewModel>> ListAll(ProductFilterQueryViewModel filters);
    }
}
