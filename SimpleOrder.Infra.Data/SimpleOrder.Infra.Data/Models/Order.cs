using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleOrder.Infra.Data.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        private readonly List<OrderProduct> _products;
        public IReadOnlyCollection<OrderProduct> Products => _products;
        public DateTime CreationDate { get; set; }

        protected Order() 
        {
            _products = new List<OrderProduct>();
        }

        public Order(string userId)
        {
            Id = Guid.NewGuid().ToString();
            UserId = userId;
            _products = new List<OrderProduct>();
        }

        public void AddProduct(string productId, decimal price, int quantity)
        {
            var product = new OrderProduct(productId, price, quantity);

            if (_products.Any(p => p.ProductId == productId))
                return;

            _products.Add(product);
        }

        public void RemoveProduct(string productId)
        {
            _products.RemoveAll(p => p.ProductId == productId);
        }
    }
}
