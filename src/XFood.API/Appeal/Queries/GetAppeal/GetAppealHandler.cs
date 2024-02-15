using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using xFood.Infrastructure;
using XFood.Data;

namespace XFood.API.Appeal.Queries.GetAppeal
{
    public class GetAppealHandler : IQueryHandler<GetAppealRequest, Result<GetAppealResponse>>
    {
        private readonly XFoodContext _db;
        public GetAppealHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetAppealResponse>> Handle(GetAppealRequest query, CancellationToken cancellation)
        {
            Data.Models.Appeal appeal = await _db.Appeals.FirstOrDefaultAsync(cl => cl.Id == query.Id);
            if (appeal != null)
            {
                AppealView appealView = new AppealView
                {
                    Id = appeal.Id,
                    Email = appeal.Email,
                    Description = appeal.Comment,
                    Materials = appeal.Materials,
                    IsApproved = appeal.IsApproved,
                    ChecklistCriteriaId = appeal.ChecklistCriteriaId,
                    CheckListId = appeal.CheckListId
                };
                return new GetAppealResponse(appealView);
            }
            else
            {
                return Result.Failure<GetAppealResponse>("Не удалось найти данные, попробуйте еще раз.");
            }
        }
    }
}
