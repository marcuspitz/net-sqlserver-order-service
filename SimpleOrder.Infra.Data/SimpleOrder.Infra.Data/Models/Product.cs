using System;

namespace SimpleOrder.Infra.Data.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }

        protected Product() { }

        public Product(string id, string name, string description, decimal price, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreationDate = creationDate;
        }
    }
}
