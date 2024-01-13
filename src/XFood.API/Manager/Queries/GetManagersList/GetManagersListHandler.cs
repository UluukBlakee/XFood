using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;
using XFood.Data.Models;

namespace XFood.API.Manager.Queries.GetManagersList
{
    public class GetManagersListHandler : IQueryHandler<GetManagersListRequest, Result<GetManagersListResponse>>
    {
        private readonly XFoodContext _db;
        public GetManagersListHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetManagersListResponse>> Handle(GetManagersListRequest query, CancellationToken cancellation)
        {
            List<Data.Models.Manager> managers = await _db.Managers.ToListAsync();
            List<ManagerView> list = managers.Select(m => new ManagerView
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Telegram = m.Telegram,
                Email = m.Email
            }).ToList();
            return new GetManagersListResponse(list);
        }
    }
}
