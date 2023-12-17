using CSharpFunctionalExtensions;
using XFood.API.Check_List.Commands.CreateCheckList;
using XFood.Data.Models;
using XFood.Data;
using xFood.Infrastructure;
using XFood.API.Check_List.Queries;
using Microsoft.EntityFrameworkCore;

namespace XFood.API.Check_List.Commands.UpdateCheckList
{
    public class UpdateCheckListHandler : ICommandHandler<UpdateCheckListRequest, Result<UpdateCheckListResponse>>
    {

        private readonly XFoodContext _db;
        public UpdateCheckListHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<UpdateCheckListResponse>> Handle(UpdateCheckListRequest command, CancellationToken cancellationToken)
        {
            CheckList checkList = await _db.CheckLists.FindAsync(command.Id);
            if (checkList  != null)
            {
                checkList.Id = command.Id;
                checkList.TotalPoints = command.TotalPoints;
                checkList.PizzeriaId = command.PizzeriaId;
                _db.Update(checkList);
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return new UpdateCheckListResponse(true);
                }
                else
                {
                    return Result.Failure<UpdateCheckListResponse>("Не удалось сохранить изменения в базе данных.");
                }
            }
            else
            {
                return Result.Failure<UpdateCheckListResponse>("Не удалось найти данные, попробуйте еще раз.");
            }
        }
    }
}
