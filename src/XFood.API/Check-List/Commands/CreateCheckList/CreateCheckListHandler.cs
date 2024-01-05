using CSharpFunctionalExtensions;
using XFood.API.Account.Commands.AccountRegister;
using xFood.Infrastructure;
using Microsoft.AspNetCore.Identity;
using XFood.Data.Models;
using XFood.Data;
using XFood.API.Check_List.Queries;

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
            XFood.Data.Models.Manager manager = await _db.Managers.FindAsync(command.ManagerId);
            var newCheckList = new CheckList { 
                PizzeriaId = manager.PizzeriaId,
                ManagerId = manager.Id,
                StartCheck = DateTime.UtcNow,
            };
            await _db.AddAsync(newCheckList);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                CheckListView checkList = new CheckListView
                {
                    Id = newCheckList.Id,
                    TotalPoints = newCheckList.TotalPoints
                }; 
                return new CreateCheckListResponse(checkList);
            }
            else
            {
                return Result.Failure<CreateCheckListResponse>("Не удалось сохранить изменения в базе данных.");
            }
        }
    }
}
