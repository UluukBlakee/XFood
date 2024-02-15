using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;
using XFood.API.Check_List.Queries;
using Microsoft.EntityFrameworkCore;
using XFood.API.CheckListCriteria.Queries;
using XFood.API.Manager.Queries;
using XFood.API.Pizzeria.Queries;
using XFood.API.Criterions.Queries;

namespace XFood.API.Check_List.Commands.CreateCheckList
{
    public class CreateCheckListHandler : ICommandHandler<CreateCheckListRequest, Result<CreateCheckListResponse>>
    {
        private readonly XFoodContext _db;

        public CreateCheckListHandler(XFoodContext context)
        {
            _db = context;
        }

        public async Task<Result<CreateCheckListResponse>> Handle(CreateCheckListRequest command, CancellationToken cancellationToken)
        {
            try
            {
                Data.Models.Manager manager = await _db.Managers.Include(m => m.Pizzeria).FirstOrDefaultAsync(m => m.Id == command.ManagerId);
                if (manager == null)
                    return Result.Failure<CreateCheckListResponse>("Менеджер не найден");

                List<Criterion> criteriaList = await _db.Criteria.Where(c => c.PizzeriaId == manager.PizzeriaId).ToListAsync();
                if (criteriaList == null || !criteriaList.Any())
                    return Result.Failure<CreateCheckListResponse>("Критерии не найдены");

                CheckList newCheckList = await CreateNewCheckList(manager);
                if (newCheckList == null)
                    return Result.Failure<CreateCheckListResponse>("Ошибка при создании нового списка проверки");

                List<CheckListCriteriaView> checkListCriteria = await CreateCheckListCriteria(criteriaList, newCheckList.Id);
                if (checkListCriteria == null || !checkListCriteria.Any())
                    return Result.Failure<CreateCheckListResponse>("Ошибка при создании критериев списка проверки");

                CheckListView checkListView = CreateCheckListView(newCheckList, manager, checkListCriteria);

                return new CreateCheckListResponse(checkListView);
            }
            catch (Exception ex)
            {
                return Result.Failure<CreateCheckListResponse>($"Произошла ошибка: {ex.Message}");
            }
        }

        private async Task<CheckList> CreateNewCheckList(Data.Models.Manager manager)
        {
            CheckList newCheckList = new CheckList
            {
                PizzeriaId = manager.PizzeriaId,
                ManagerId = manager.Id,
                StartCheck = DateTime.UtcNow,
                TotalPoints = 0,
                EndCheck = null
            };
            _db.Add(newCheckList);
            int result = await _db.SaveChangesAsync();
            return result > 0 ? newCheckList : null;
        }

        private async Task<List<CheckListCriteriaView>> CreateCheckListCriteria(List<Criterion> criteriaList, int checkListId)
        {
            List<CheckListCriteriaView> checkListCriteria = new List<CheckListCriteriaView>();
            foreach (var criterion in criteriaList)
            {
                ChecklistCriteria checklistCriteria = new ChecklistCriteria
                {
                    CheckListId = checkListId,
                    CriterionId = criterion.Id,
                    ReceivedPoints = 0
                };
                _db.Add(checklistCriteria);
                await _db.SaveChangesAsync();
                CheckListCriteriaView criteriaView = new CheckListCriteriaView
                {
                    Id = checklistCriteria.Id,
                    Criterion = new CriterionView
                    {
                        Id = criterion.Id,
                        Name = criterion.Name,
                        Section = criterion.Section,
                        MaxPoints = criterion.MaxPoints
                    },
                    ReceivedPoints = 0
                };
                checkListCriteria.Add(criteriaView);
            }
            return checkListCriteria;
        }

        private CheckListView CreateCheckListView(CheckList newCheckList, Data.Models.Manager manager, List<CheckListCriteriaView> checkListCriteria)
        {
            return new CheckListView
            {
                Id = newCheckList.Id,
                Pizzeria = new PizzeriaView
                {
                    Name = manager.Pizzeria.Name
                },
                StartCheck = newCheckList.StartCheck,
                Manager = new ManagerView
                {
                    FirstName = manager.FirstName,
                    LastName = manager.LastName
                },
                Criteria = checkListCriteria
            };
        }
    }
}
