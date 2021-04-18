using SimpleOrder.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleOrder.Application.Services.Interfaces
{
    public interface IOrderAppService
    {
        Task<OrderViewModel> Add(OrderInsertViewModel product);
        Task<OrderViewModel> Get(string id);
        Task<IEnumerable<OrderViewModel>> ListAll();
    }
}
