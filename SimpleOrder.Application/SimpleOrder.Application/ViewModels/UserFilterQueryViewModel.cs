using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleOrder.Application.ViewModels
{
    public class UserFilterQueryViewModel
    {
        [FromQuery(Name = "u")]
        public string UserName { get; set; }

        [FromQuery(Name = "d")]
        public string DisplayName { get; set; }

        [FromQuery(Name = "s")]
        public DateTime? StartDate { get; set; }

        [FromQuery(Name = "e")]
        public DateTime? EndDate { get; set; }

        [FromQuery(Name = "m")]
        public string Email { get; set; }
    }
}
