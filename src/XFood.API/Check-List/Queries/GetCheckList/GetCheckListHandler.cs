using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XFood.API.Check_List.Queries.GetCheckList;
using XFood.API.Check_List.Queries.GetCheckListAll;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;
using XFood.API.Manager.Queries;
using XFood.API.Pizzeria.Queries;

namespace XFood.API.Check_List.Queries.GetCheckList
{
    public class GetCheckListHandler : IQueryHandler<GetCheckListRequest, Result<GetCheckListResponse>>
    {
        private readonly XFoodContext _db;

        public GetCheckListHandler(XFoodContext context)
        {
            _db = context;
        }

        public async Task<Result<GetCheckListResponse>> Handle(GetCheckListRequest query, CancellationToken cancellation)
        {
            CheckList checkList = await _db.CheckLists
                .Include(cl => cl.Pizzeria)
                .FirstOrDefaultAsync(cl => cl.Id == query.Id);

            if (checkList != null)
            {
                CheckListView newCheckList = MapCheckListToView(checkList);
                return new GetCheckListResponse(newCheckList);
            }
            else
            {
                return Result.Failure<GetCheckListResponse>("Не удалось найти данные, попробуйте еще раз.");
            }
        }

        private CheckListView MapCheckListToView(CheckList checkList)
        {
            return new CheckListView
            {
                Id = checkList.Id,
                Pizzeria = MapPizzeria(checkList.Pizzeria),
                TotalPoints = checkList.TotalPoints,
                StartCheck = checkList.StartCheck,
                EndCheck = checkList.EndCheck,
                Manager = MapManager(checkList.Manager)
            };
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
                Telegram = manager.Telegram,
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
