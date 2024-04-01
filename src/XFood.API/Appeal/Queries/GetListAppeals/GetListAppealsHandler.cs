using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;
using XFood.Data.Models;

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
                Comment = a.Comment,
                Materials = a.Materials,
                IsApproved = a.IsApproved,
                CheckListId = a.CheckListId,
                Status = a.Status,
                DateApplication = a.DateApplication,
                DateReply = a.DateReply,
                Reply = a.Reply
            }).ToList();
            return new GetListAppealsResponse(list);
        }
    }
}
