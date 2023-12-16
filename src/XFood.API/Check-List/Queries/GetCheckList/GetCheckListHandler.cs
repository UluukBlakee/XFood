using CSharpFunctionalExtensions;
using XFood.API.Check_List.Queries.GetCheckListAll;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;
using Microsoft.EntityFrameworkCore;
using XFood.API.Employee.Queries.GetEmployeeList;
using XFood.API.Employee.Queries;

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
            CheckList checkList = await _db.CheckLists.Include(cl => cl.Pizzeria).Include(cl => cl.Criteria).Include(cl => cl.CategoryFactors).FirstOrDefaultAsync(cl => cl.Id == query.Id);
            CheckListView newCheckList = new CheckListView
            {
                Id = checkList.Id,
                CategoryFactors = checkList.CategoryFactors,
                Criteria = checkList.Criteria,
                TotalPoints = checkList.TotalPoints,
                Pizzeria = checkList.Pizzeria
            };
            return new GetCheckListResponse(newCheckList);
        }
    }
}
