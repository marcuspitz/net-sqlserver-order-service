using System.Collections.Generic;

namespace SimpleOrder.Application.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
    }

    public class OrderInsertViewModel
    {
        public string UserId { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
    }

    public class OrderProductViewModel
    {
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
