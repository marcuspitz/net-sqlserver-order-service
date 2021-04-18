
using System.Collections.Generic;

namespace SimpleOrder.Application.ViewModels
{
    public class AppResponseViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
