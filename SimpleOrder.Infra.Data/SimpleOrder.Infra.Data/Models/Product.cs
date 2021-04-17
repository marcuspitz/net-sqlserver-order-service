using System;

namespace SimpleOrder.Infra.Data.Models
{
    public class Product
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
