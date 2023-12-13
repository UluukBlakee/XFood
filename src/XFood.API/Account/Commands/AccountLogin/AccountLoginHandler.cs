using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using XFood.Data.Models;
using xFood.Infrastructure;

namespace XFood.API.Account.Commands.AccountLogin
{
    public class AccountLoginHandler : ICommandHandler<AccountLoginRequest, Result<AccountLoginResponse>>
    {
        private readonly JWTSettings _settings;
        private readonly SignInManager<User> _signInManager;

        public AccountLoginHandler(IOptions<JWTSettings> options,
            SignInManager<User> signInManager)
        {
            _settings = options.Value;
            _signInManager = signInManager;
        }

        public async Task<Result<AccountLoginResponse>> Handle(AccountLoginRequest command,
            CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, false);
            if (!result.Succeeded)
                return Result.Failure<AccountLoginResponse>("Username or password are invalid.");

            var user = await _signInManager.UserManager.FindByEmailAsync(command.Email);
            var roles = await _signInManager.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, command.Email)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = _settings.JwtSecurityKey;
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_settings.JwtExpiryInDays));
            var token = new JwtSecurityToken(
                _settings.JwtIssuer,
                _settings.JwtAudience,
                claims,
                expires: expiry,
                signingCredentials: creds
            );
            return new AccountLoginResponse(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}