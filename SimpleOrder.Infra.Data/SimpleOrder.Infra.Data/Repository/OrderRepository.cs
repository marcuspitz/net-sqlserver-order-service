using Microsoft.EntityFrameworkCore;
using SimpleOrder.Infra.Data.Models;
using SimpleOrder.Infra.Data.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleOrder.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;

        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(string userId, List<OrderProduct> products)
        {
            var order = new Order(userId);
            foreach(var product in products)
            {
                order.AddProduct(product.Id, product.Price, product.Quantity);
            }
            var obj = await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }

        public Task<Order> Get(string id)
        {
            return _context.Order.Include(o => o.Products).FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Order>> ListAll()
        {
            return _context.Order.Include(o => o.Products).ToListAsync();
        }
    }
}
