using SimpleOrder.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleOrder.Infra.Data.Repository.Interface
{
    public interface IProductRepository
    {
        Task<Product> Get(string id);
        Task<Product> Add(string name, string description, decimal price);
        Task<Product> Update(string id, string name, string description, decimal price);
        Task<List<Product>> ListAll(string name, string description, DateTime? startDate, DateTime? endDate);
    }
}
