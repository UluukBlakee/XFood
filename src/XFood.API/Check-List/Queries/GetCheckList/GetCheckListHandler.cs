using CSharpFunctionalExtensions;
using XFood.API.Check_List.Queries.GetCheckListAll;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;
using Microsoft.EntityFrameworkCore;

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
            CheckList checkList = await _db.CheckLists.FirstOrDefaultAsync(cl => cl.Id == query.id);
            CheckListView newCheckList = new CheckListView
            {
                CategoryFactors = checkList.CategoryFactors,
                Criteria = checkList.Criteria,
                TotalPoints = checkList.TotalPoints,
                Pizzeria = checkList.Pizzeria
            };
            return new GetCheckListResponse(newCheckList);
        }
    }
}
