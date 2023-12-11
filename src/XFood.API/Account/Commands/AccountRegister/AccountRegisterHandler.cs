using CSharpFunctionalExtensions;
using XFood.API.Employee.Queries.GetEmployeeList;
using xFood.Infrastructure;
using Microsoft.AspNetCore.Identity;
using XFood.Data.Models;

namespace XFood.API.Account.Commands.AccountRegister
{
    public class AccountRegisterHandler : ICommandHandler<AccountRegisterRequest, Result<AccountRegisterResponse>>
    {
        private readonly UserManager<User> _userManager;

        public AccountRegisterHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<AccountRegisterResponse>> Handle(AccountRegisterRequest command, CancellationToken cancellationToken)
        {
            var newUser = new User { UserName = command.Email, Email = command.Email };
            var result = await _userManager.CreateAsync(newUser, command.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return Result.Failure<AccountRegisterResponse>(String.Join("\n",errors.ToArray()));
            }
            return new AccountRegisterResponse();
        }
    }
    }

