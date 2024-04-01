using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using xFood.Infrastructure;
using XFood.API.CheckListCriteria.Queries;
using XFood.API.Criterions.Queries;
using XFood.Data;
using XFood.Data.Models;

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
            Data.Models.Appeal appeal = await _db.Appeals.Include(c => c.ChecklistCriteria).ThenInclude(cl => cl.Criterion).FirstOrDefaultAsync(cl => cl.Id == query.Id);
            if (appeal != null)
            {
                AppealView appealView = new AppealView
                {
                    Id = appeal.Id,
                    Email = appeal.Email,
                    Comment = appeal.Comment,
                    Materials = appeal.Materials,
                    IsApproved = appeal.IsApproved,
                    ChecklistCriteria = new CheckListCriteriaView()
                    {
                        Id = appeal.ChecklistCriteria.Id,
                        ReceivedPoints = appeal.ChecklistCriteria.ReceivedPoints,
                        Criterion = new CriterionView()
                        {
                            Name = appeal.ChecklistCriteria.Criterion.Name,
                            MaxPoints = appeal.ChecklistCriteria.Criterion.MaxPoints,
                            Section = appeal.ChecklistCriteria.Criterion.Section
                        },
                    },
                    Status = appeal.Status,
                    DateApplication = appeal.DateApplication, 
                    DateReply = appeal.DateReply,
                    Reply = appeal.Reply,
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
