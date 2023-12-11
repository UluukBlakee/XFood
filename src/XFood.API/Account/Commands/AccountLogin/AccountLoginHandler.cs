using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XFood.API.Account.Commands.AccountRegister;
using xFood.Infrastructure;

namespace XFood.API.Account.Commands.AccountLogin
{
    public class AccountLoginHandler : ICommandHandler<AccountLoginRequest, Result<AccountLoginResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<Data.Models.User> _signInManager;

        public AccountLoginHandler(IConfiguration configuration,
                               SignInManager<Data.Models.User> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }
        public async Task<Result<AccountLoginResponse>> Handle(AccountLoginRequest command, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, false);
            if (!result.Succeeded)
                return Result.Failure<AccountLoginResponse>("Username or password are invalid.");
            var claims = new[]{new Claim(ClaimTypes.Name, command.Email)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));
            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds

            );
            return new AccountLoginResponse(new JwtSecurityTokenHandler().WriteToken(token)); ;
        }
    }
}

