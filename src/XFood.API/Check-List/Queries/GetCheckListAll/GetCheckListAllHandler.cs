using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using Microsoft.EntityFrameworkCore;
using XFood.Data.Models;
using XFood.API.Pizzeria.Queries;
using XFood.API.Manager.Queries;

namespace XFood.API.Check_List.Queries.GetCheckListAll
{
    public class GetCheckListAllHandler : IQueryHandler<GetCheckListAllRequest, Result<GetCheckListAllResponse>>
    {
        private readonly XFoodContext _db;
        public GetCheckListAllHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<GetCheckListAllResponse>> Handle(GetCheckListAllRequest query, CancellationToken cancellation)
        {
            List<CheckList> checkLists = await _db.CheckLists
                .Include(cl => cl.Pizzeria)
                .Include(cl => cl.Manager)
                .ToListAsync();

            List<CheckListView> list = checkLists.Select(cl => new CheckListView
            {
                Id = cl.Id,
                Pizzeria = MapPizzeria(cl.Pizzeria),
                TotalPoints = cl.TotalPoints,
                StartCheck = cl.StartCheck,
                EndCheck = cl.EndCheck,
                Manager = MapManager(cl.Manager)
            }).ToList();

            return new GetCheckListAllResponse(list);
        }

        private ManagerView MapManager(Data.Models.Manager? manager)
        {
            if (manager == null)
                return null;

            return new ManagerView
            {
                Id = manager.Id,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Telegram =  manager.Telegram,
                Email = manager.Email
            };
        }

        private PizzeriaView MapPizzeria(Data.Models.Pizzeria? pizzeria)
        {
            if (pizzeria == null)
                return null;

            return new PizzeriaView
            {
                Id = pizzeria.Id,
                Name = pizzeria.Name,
                Region = pizzeria.Region
            };
        }
    }
}
