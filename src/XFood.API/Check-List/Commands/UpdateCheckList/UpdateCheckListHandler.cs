using CSharpFunctionalExtensions;
using XFood.API.Check_List.Commands.CreateCheckList;
using XFood.Data.Models;
using XFood.Data;
using xFood.Infrastructure;
using XFood.API.Check_List.Queries;

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
            CheckList checkList = new CheckList
            {
                Id = command.CheckList.Id,
                TotalPoints = command.CheckList.TotalPoints,
                PizzeriaId = command.CheckList.Pizzeria.Id
            };
            _db.Update(checkList);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                return Result.Success(new UpdateCheckListResponse(true));
            }
            else
            {
                return Result.Failure<UpdateCheckListResponse>("Не удалось сохранить изменения в базе данных.");
            }
        }
    }
}
