using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SimpleOrder.Application.Services.Interfaces;
using SimpleOrder.Application.ViewModels;
using SimpleOrder.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleOrder.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly ILogger<UserAppService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserAppService(ILogger<UserAppService> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IEnumerable<UserResponseViewModel> GetUser(UserFilterQueryViewModel filters)
        {
            try
            {
                IQueryable<ApplicationUser> query = _userManager.Users;
                if (!String.IsNullOrEmpty(filters.UserName))
                {
                    query = query.Where(u => u.UserName.ToLower() == filters.UserName.ToLower());
                }
                if (!String.IsNullOrEmpty(filters.DisplayName))
                {
                    query = query.Where(u => u.DisplayName.ToLower().Contains(filters.DisplayName.ToLower()));
                }
                if (filters.StartDate.HasValue)
                {
                    query = query.Where(u => u.CreationDate >= filters.StartDate.Value);
                }
                if (filters.EndDate.HasValue)
                {
                    query = query.Where(u => u.CreationDate <= filters.EndDate.Value);
                }
                if (!String.IsNullOrEmpty(filters.Email))
                {
                    query = query.Where(u => u.Email.ToLower() == filters.Email.ToLower());
                }
                return query.ToList().Select(u => new UserResponseViewModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    DisplayName = u.DisplayName,
                    UserName = u.UserName,
                    CreationDate = u.CreationDate
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when retrieving users: {e.Message}");
                _logger.LogTrace(e.StackTrace);
            }
            return new List<UserResponseViewModel>();
        }
    }
}
