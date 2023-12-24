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
        public async Task<Result<GetManagersListResponse>> Handle(GetManagersListRequest query, CancellationToken cancellation)
        {
            List<Data.Models.Manager> managers = await _db.Managers.Include(cl => cl.Pizzeria).ToListAsync();
            List<ManagerView> list = managers.Select(m => new ManagerView
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                PizzeriaId = m.PizzeriaId,
                Pizzeria = m.Pizzeria
            }).ToList();
            return new GetManagersListResponse(list);
        }
    }
}
