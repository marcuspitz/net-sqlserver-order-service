using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOrder.Infra.Data.Models
{
    public class OrderProduct
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }

        protected OrderProduct() { }

        public OrderProduct(string productId, decimal price, int quantity)
        {
            Id = Guid.NewGuid().ToString();
            Price = price;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}
