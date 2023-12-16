using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using Microsoft.EntityFrameworkCore;
using XFood.Data.Models;

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
            List<CheckList> checkLists = await _db.CheckLists.Include(cl => cl.Pizzeria).Include(cl => cl.Criteria).Include(cl => cl.CategoryFactors).ToListAsync();
            List<CheckListView> list = checkLists.Select(cl => new CheckListView
            {
                CategoryFactors = cl.CategoryFactors,
                Criteria = cl.Criteria,
                TotalPoints = cl.TotalPoints,
                Pizzeria = cl.Pizzeria
            }).ToList();
            return new GetCheckListAllResponse(list);
        }
    }
}
