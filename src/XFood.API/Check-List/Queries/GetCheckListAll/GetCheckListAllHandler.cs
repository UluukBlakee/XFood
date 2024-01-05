using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using Microsoft.EntityFrameworkCore;
using XFood.Data.Models;
using XFood.API.Employee.Queries.GetEmployeeList;
using XFood.API.Employee.Queries;

namespace XFood.API.Check_List.Queries.GetCheckListAll
{
    public class GetCheckListAllHandler : IQueryHandler<GetCheckListAllRequest, Result<GetCheckListAllResponse>>
    {
        private readonly XFoodContext _db;
        public GetCheckListAllHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetCheckListAllResponse>> Handle(GetCheckListAllRequest query,CancellationToken cancellation)
        {
            List<CheckList> checkLists = await _db.CheckLists.Include(cl => cl.Pizzeria).ToListAsync();
            List<CheckListView> list = checkLists.Select(cl => new CheckListView
            {
                Id = cl.Id,
                TotalPoints = cl.TotalPoints,
            }).ToList();
            return new GetCheckListAllResponse(list);
        }
    }
}
