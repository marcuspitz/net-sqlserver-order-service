using Microsoft.AspNetCore.Identity;
using System;

namespace SimpleOrder.Infra.Data.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime CreationDate { get; set; }
    }
}
