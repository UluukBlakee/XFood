using CSharpFunctionalExtensions;
using XFood.API.Check_List.Queries.GetCheckListAll;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;
using Microsoft.EntityFrameworkCore;
using XFood.API.Employee.Queries.GetEmployeeList;
using XFood.API.Employee.Queries;
using XFood.API.Check_List.Commands.CreateCheckList;
using XFood.API.Check_List.Commands.DeleteCheckList;

namespace XFood.API.Check_List.Queries.GetCheckList
{
    public class GetCheckListHandler : IQueryHandler<GetCheckListRequest, Result<GetCheckListResponse>>
    {
        private readonly XFoodContext _db;
        public GetCheckListHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetCheckListResponse>> Handle(GetCheckListRequest query, CancellationToken cancellation)
        {
            CheckList checkList = await _db.CheckLists.Include(cl => cl.Pizzeria).FirstOrDefaultAsync(cl => cl.Id == query.Id);
            if (checkList != null)
            {
                CheckListView newCheckList = new CheckListView
                {
                    Id = checkList.Id,
                    TotalPoints = checkList.TotalPoints
                };
                return new GetCheckListResponse(newCheckList);
            }
            else
            {
                return Result.Failure<GetCheckListResponse>("Не удалось найти данные, попробуйте еще раз.");
            }
        }
    }
}
