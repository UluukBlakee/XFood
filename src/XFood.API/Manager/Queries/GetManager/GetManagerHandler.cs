using CSharpFunctionalExtensions;
using XFood.API.Check_List.Queries.GetCheckList;
using xFood.Infrastructure;
using XFood.API.Check_List.Queries;
using XFood.Data.Models;
using XFood.Data;
using Microsoft.EntityFrameworkCore;

namespace XFood.API.Manager.Queries.GetManager
{
    public class GetManagerHandler : IQueryHandler<GetManagerRequest, Result<GetManagerResponse>>
    {
        private readonly XFoodContext _db;
        public GetManagerHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetManagerResponse>> Handle(GetManagerRequest query, CancellationToken cancellation)
        {
            Data.Models.Manager manager = await _db.Managers.Include(cl => cl.Pizzeria).FirstOrDefaultAsync(cl => cl.Id == query.Id);
            if (manager != null)
            {
                ManagerView managerView = new ManagerView
                {
                    Id = manager.Id,
                    FirstName = manager.FirstName,
                    LastName = manager.LastName,
                    PizzeriaId = manager.PizzeriaId,
                    Pizzeria = manager.Pizzeria
                };
                return new GetManagerResponse(managerView);
            }
            else
            {
                return Result.Failure<GetManagerResponse>("Не удалось найти данные, попробуйте еще раз.");
            }
        }
    }
}
