using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleOrder.Application.ViewModels
{
    public class ProductFilterQueryViewModel
    {
        [FromQuery(Name = "n")]
        public string Name { get; set; }

        [FromQuery(Name = "d")]
        public string Description { get; set; }

        [FromQuery(Name = "s")]
        public DateTime? StartDate { get; set; }

        [FromQuery(Name = "e")]
        public DateTime? EndDate { get; set; }
    }
}
