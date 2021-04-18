using Microsoft.AspNetCore.Identity;
using System;

namespace SimpleOrder.Infra.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
