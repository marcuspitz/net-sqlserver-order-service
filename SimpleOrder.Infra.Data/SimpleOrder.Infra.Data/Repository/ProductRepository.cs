using Microsoft.EntityFrameworkCore;
using SimpleOrder.Infra.Data.Models;
using SimpleOrder.Infra.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleOrder.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(string name, string description, decimal price)
        {
            var product = new Product(Guid.NewGuid().ToString(), name, description, price, DateTime.UtcNow);
            var obj = await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }

        public Task<Product> Get(string id)
        {
            return _context.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Product>> ListAll(string name, string description, DateTime? startDate, DateTime? endDate)
        {
            IQueryable<Product> query = _context.Product;
            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.ToLower() == name.ToLower());
            }
            if (!String.IsNullOrEmpty(description))
            {
                query = query.Where(p => p.Description.ToLower().Contains(description.ToLower()));
            }
            if (startDate.HasValue)
            {
                query = query.Where(u => u.CreationDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(u => u.CreationDate <= endDate.Value);
            }
            return query.ToListAsync();
        }

        public async Task<Product> Update(string id, string name, string description, decimal price)
        {
            var model = await Get(id);
            if (model != null)
            {
                model.Name = name;
                model.Description = description;
                model.Price = price;
                await _context.SaveChangesAsync();
                return model;
            }
            else
            {
                throw new Exception($"Product {id}-{name} not found");
            }
        }
    }
}
