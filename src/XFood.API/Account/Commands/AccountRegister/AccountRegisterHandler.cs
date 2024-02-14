using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using Microsoft.AspNetCore.Identity;
using XFood.Data.Models;

namespace XFood.API.Account.Commands.AccountRegister
{
    public class AccountRegisterHandler : ICommandHandler<AccountRegisterRequest, Result<AccountRegisterResponse>>
    {
        private readonly UserManager<XFood.Data.Models.User> _userManager;


        public AccountRegisterHandler(UserManager<XFood.Data.Models.User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<AccountRegisterResponse>> Handle(AccountRegisterRequest command, CancellationToken cancellationToken)
        {
            var newUser = new XFood.Data.Models.User { UserName = command.UserName, Email = command.Email };
            var result = await _userManager.CreateAsync(newUser, command.Password);
            await _userManager.AddToRoleAsync(newUser, "User");
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return Result.Failure<AccountRegisterResponse>(string.Join("\n",errors.ToArray()));
            }
            return new AccountRegisterResponse(true);
        }
    }
    }

