using SimpleOrder.Infra.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleOrder.Infra.Data.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<Order> Get(string id);
        Task<Order> Add(string userId, List<OrderProduct> products);
        Task<List<Order>> ListAll();
    }
}
