using CSharpFunctionalExtensions;
using XFood.API.Check_List.Queries.GetCheckListAll;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;
using Microsoft.EntityFrameworkCore;

namespace XFood.API.Pizzeria.Queries.GetPizzeria
{
    public class GetPizzeriaHandler : IQueryHandler<GetPizzeriaRequest, Result<GetPizzeriaResponse>>
    {
        private readonly XFoodContext _context;
        public GetPizzeriaHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<GetPizzeriaResponse>> Handle(GetPizzeriaRequest query, CancellationToken cancellation)
        {
            XFood.Data.Models.Pizzeria pizzeria = await _context.Pizzerias.FirstOrDefaultAsync(cl => cl.Id == query.Id);
            if (pizzeria != null)
            {
                PizzeriaView newPizzeria = new PizzeriaView
                {
                    Id = pizzeria.Id,
                    Name = pizzeria.Name,
                    Region = pizzeria.Region
                };
                return new GetPizzeriaResponse(newPizzeria);
            }
            else
            {
                return Result.Failure<GetPizzeriaResponse>("Не удалось найти данные, попробуйте еще раз.");
            }
        }
    }
}
