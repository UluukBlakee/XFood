using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace XFood.API.Manager.Queries.GetManagersList
{
    public class GetManagersListHandler : IQueryHandler<GetManagersListRequest, Result<GetManagersListResponse>>
    {
        private readonly XFoodContext _db;

        public GetManagersListHandler(XFoodContext context)
        {
            _db = context;
        }

        public async Task<Result<GetManagersListResponse>> Handle(GetManagersListRequest query,
            CancellationToken cancellation)
        {
            var managersQuery = _db.Managers
                .When(query.SearchTerm.IsNotEmpty, then =>
                    then.Where(x => EF.Functions.Like(x.FirstName, $"%{query.SearchTerm}%") ||
                                    EF.Functions.Like(x.LastName, $"%{query.SearchTerm}%") ||
                                    EF.Functions.Like(x.Telegram, $"%{query.SearchTerm}%") ||
                                    EF.Functions.Like(x.Email, $"%{query.SearchTerm}%")));

            var managers = await managersQuery
                .ToPage(query.PageNumber, query.PageSize)
                .Select(m => new ManagerView
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Telegram = m.Telegram,
                    Email = m.Email
                })
                .ToListAsync(cancellation);

            var managersCount = await managersQuery.CountAsync(cancellation);
            
            return new GetManagersListResponse(managers)
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalCount = managersCount
            };
        }
    }
}