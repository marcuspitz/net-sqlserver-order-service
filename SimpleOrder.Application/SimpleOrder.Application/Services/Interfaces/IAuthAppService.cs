using SimpleOrder.Application.ViewModels;
using System.Threading.Tasks;

namespace SimpleOrder.Application.Services.Interfaces
{
    public interface IAuthAppService
    {
        Task<AppResponseViewModel> Signup(UserRequestViewModel request);
        Task<SigninResultViewModel> Signin(SigninRequestViewModel request);
    }
}
