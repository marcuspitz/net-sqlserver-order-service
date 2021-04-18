using SimpleOrder.Application.ViewModels;
using System.Collections.Generic;

namespace SimpleOrder.Application.Services.Interfaces
{
    public interface IUserAppService
    {
        IEnumerable<UserResponseViewModel> GetUser(UserFilterQueryViewModel filters);
    }
}
