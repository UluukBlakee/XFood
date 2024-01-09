using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using Microsoft.EntityFrameworkCore;
using XFood.Data.Models;

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
            List<XFood.Data.Models.Pizzeria> pizzerias = await _context.Pizzerias.ToListAsync();
            List<PizzeriaView> list = pizzerias.Select(p => new PizzeriaView {
                Id = p.Id,
                Name = p.Name,
                Region = p.Region
            }).ToList();
            return new GetPizzeriaListResponse(list);
        }
    }
}
