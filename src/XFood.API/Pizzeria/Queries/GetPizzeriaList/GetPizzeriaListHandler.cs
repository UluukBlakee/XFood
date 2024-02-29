using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using Microsoft.EntityFrameworkCore;
using XFood.Data.Models;
using XFood.API.Manager.Queries;

namespace XFood.API.Pizzeria.Queries.GetPizzeriaList
{
    public class GetPizzeriaListHandler : IQueryHandler<GetPizzeriaListRequest, Result<GetPizzeriaListResponse>>
    {
        private readonly XFoodContext _context;

        public GetPizzeriaListHandler(XFoodContext context)
        {
            _context = context;
        }

        public async Task<Result<GetPizzeriaListResponse>> Handle(GetPizzeriaListRequest query, CancellationToken cancellationToken)
        {
            List<XFood.Data.Models.Pizzeria> pizzerias = await _context.Pizzerias.Include(p => p.Managers).ToListAsync();
            List<PizzeriaView> list = pizzerias.Select(p => new PizzeriaView {
                Id = p.Id,
                Name = p.Name,
                Region = p.Region,
                Managers = p.Managers.Select(m => new ManagerView
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Telegram = m.Telegram,
                    Email = m.Email
                }).ToList(),
            }).ToList();
            return new GetPizzeriaListResponse(list);
        }
    }
}
