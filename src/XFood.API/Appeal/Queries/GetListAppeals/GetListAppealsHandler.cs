using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace XFood.API.Appeal.Queries.GetListAppeals
{
    public class GetListAppealsHandler : IQueryHandler<GetListAppealsRequest, Result<GetListAppealsResponse>>
    {
        private readonly XFoodContext _db;
        public GetListAppealsHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetListAppealsResponse>> Handle(GetListAppealsRequest query, CancellationToken cancellation)
        {
            List<Data.Models.Appeal> appeals = await _db.Appeals.ToListAsync();
            List<AppealView> list = appeals.Select(a => new AppealView
            {
                Id = a.Id,
                Email = a.Email,
                Description = a.Description,
                Materials = a.Materials,
                IsApproved = a.IsApproved,
                ChecklistCriteriaId = a.ChecklistCriteriaId,
                CheckListId = a.CheckListId
            }).ToList();
            return new GetListAppealsResponse(list);
        }
    }
}
