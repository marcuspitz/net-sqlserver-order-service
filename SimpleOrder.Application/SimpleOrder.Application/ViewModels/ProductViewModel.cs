using System;

namespace SimpleOrder.Application.ViewModels
{
    public class ProductViewModel : ProductInsertViewModel
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
