using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleOrder.Application.Services.Interfaces;
using SimpleOrder.Application.Settings;
using SimpleOrder.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrder.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenSettings _tokenSettings;
        private readonly ILogger<AuthAppService> _logger;

        public AuthAppService(UserManager<IdentityUser> userManager, IOptionsSnapshot<TokenSettings> tokenSettings, ILogger<AuthAppService> logger)
        {
            _userManager = userManager;
            _tokenSettings = tokenSettings.Value;
            _logger = logger;
        }

        public async Task<SigninResultViewModel> Signin(SigninRequestViewModel request)
        {
            try
            {
                var user = _userManager.Users.SingleOrDefault(u => u.UserName == request.UserName);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, request.Password))
                    {
                        return new SigninResultViewModel()
                        {
                            Success = true,
                            UserId = user.Id,
                            AccessToken = GenerateJwt(user)
                        };
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong when signin: {e.Message}");
            }            
            return new SigninResultViewModel()
            {
                Success = false,
                Message = "User name or password incorrect"
            };
        }

        public async Task<AppResponseViewModel> Signup(UserRequestViewModel request)
        {
            try
            {
                var user = new IdentityUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    NormalizedUserName = request.DisplayName,
                    UserName = request.UserName,
                    Email = request.Email
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    return new AppResponseViewModel()
                    {
                        Success = true,
                        Message = "User successfully created",                        
                    };
                }
                else
                {
                    return new AppResponseViewModel()
                    {
                        Success = false,
                        Message = "Validation errors",
                        Errors = result.Errors.Select(e => e.Description)
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong when signup: {e.Message}");
            }            
            return new AppResponseViewModel()
            {
                Success = false,
                Message = "Something went wrong"
            };
        }

        private string GenerateJwt(IdentityUser user)
        {
            var claims = new List<Claim>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_tokenSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
