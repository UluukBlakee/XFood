using CSharpFunctionalExtensions;
using XFood.API.Account.Commands.AccountRegister;
using xFood.Infrastructure;
using Microsoft.AspNetCore.Identity;
using XFood.Data.Models;
using XFood.Data;

namespace XFood.API.Check_List.Commands.CreateCheckList
{
    public class CreateCheckListHandler : ICommandHandler<CreateCheckListRequest, Result<CreateCheckListResponse>>
    {
        private readonly XFoodContext _db;
        public CreateCheckListHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<CreateCheckListResponse>> Handle(CreateCheckListRequest command, CancellationToken cancellationToken)
        {
            var newCheckList = new CheckList { PizzeriaId = command.PizzeriaId};
            await _db.AddAsync(newCheckList);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                return Result.Success(new CreateCheckListResponse(true));
            }
            else
            {
                return Result.Failure<CreateCheckListResponse>("Не удалось сохранить изменения в базе данных.");
            }
        }
    }
}
