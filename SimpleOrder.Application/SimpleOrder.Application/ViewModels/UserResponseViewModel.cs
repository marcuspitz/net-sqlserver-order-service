
using System;

namespace SimpleOrder.Application.ViewModels
{
    public class UserResponseViewModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
