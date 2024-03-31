using CSharpFunctionalExtensions;
using XFood.API.Check_List.Queries.GetCheckList;
using XFood.Data.Models;
using XFood.Data;
using xFood.Infrastructure;
using XFood.API.Pizzeria.Queries;
using XFood.API.Manager.Queries;
using XFood.API.Criterions.Queries;
using XFood.API.CheckListCriteria.Queries;
using XFood.API.Check_List.Queries;
using Microsoft.EntityFrameworkCore;
using XFood.API.CriticalFactors.Queries;

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
                .Include(cl => cl.Manager)
                .Include(cl => cl.Criteria)
                    .ThenInclude(cc => cc.Criterion)
                .Include(cl => cl.CriticalFactor)
                .FirstOrDefaultAsync(cl => cl.Id == query.Id);

            if (checkList != null)
            {
                CheckListView checkListView = MapCheckListToView(checkList);
                return new GetCheckListResponse(checkListView);
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
                Manager = MapManager(checkList.Manager),
                Criteria = MapCheckListCriteria(checkList.Criteria),
                CriticalFactors = MapCriticalFactor(checkList.CriticalFactor)
            };
        }

        private List<CheckListCriteriaView> MapCheckListCriteria(List<ChecklistCriteria> criteria)
        {
            return criteria.Select(cc => new CheckListCriteriaView
            {
                Id = cc.Id,
                Criterion = MapCriterion(cc.Criterion),
                ReceivedPoints = cc.ReceivedPoints
            }).ToList();
        }
        private List<CriticalFactorView> MapCriticalFactor(List<CriticalFactor> criticalFactors)
        {
            return criticalFactors.Select(c => new CriticalFactorView
            {
                Id = c.Id,
                CriterionId = c.CriterionId,   
                MaxPoints = c.MaxPoints,
            }).ToList();
        }

        private CriterionView MapCriterion(Criterion criterion)
        {
            return new CriterionView
            {
                Id = criterion.Id,
                Name = criterion.Name,
                Section = criterion.Section,
                MaxPoints = criterion.MaxPoints
            };
        }

        private ManagerView MapManager(Data.Models.Manager manager)
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

        private PizzeriaView MapPizzeria(Data.Models.Pizzeria pizzeria)
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