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
                Data.Models.User user = await _db.Users.FirstOrDefaultAsync(u => u.Id == command.UserId);
                if (manager == null)
                    return Result.Failure<CreateCheckListResponse>("Менеджер не найден");

                List<Criterion> criteriaList = await _db.Criteria.Where(c => c.PizzeriaId == manager.PizzeriaId).ToListAsync();
                if (criteriaList == null || !criteriaList.Any())
                    return Result.Failure<CreateCheckListResponse>("Критерии не найдены");

                int newCHeckListId = await CreateNewCheckList(manager, user);
                if (newCHeckListId == 0)
                    return Result.Failure<CreateCheckListResponse>("Ошибка при создании нового списка проверки");

                bool areCriteriaCreated = await CreateCheckListCriteria(criteriaList, newCHeckListId);
                if (!areCriteriaCreated)
                    return Result.Failure<CreateCheckListResponse>("Ошибка при создании критериев списка проверки");

                return new CreateCheckListResponse(true);
            }
            catch (Exception ex)
            {
                return Result.Failure<CreateCheckListResponse>($"Произошла ошибка: {ex.Message}");
            }
        }

        private async Task<int> CreateNewCheckList(Data.Models.Manager manager, Data.Models.User user)
        {
            CheckList newCheckList = new CheckList
            {
                PizzeriaId = manager.PizzeriaId,
                ManagerId = manager.Id,
                StartCheck = DateTime.UtcNow,
                TotalPoints = 0,
                EndCheck = null,
                UserId = user.Id,
                Status = "active"
            };
            _db.Add(newCheckList);
            int result = await _db.SaveChangesAsync();
            return result > 0 ? newCheckList.Id : 0;
        }

        private async Task<bool> CreateCheckListCriteria(List<Criterion> criteriaList, int checkListId)
        {
            foreach (var criterion in criteriaList)
            {
                ChecklistCriteria checklistCriteria = new ChecklistCriteria
                {
                    CheckListId = checkListId,
                    CriterionId = criterion.Id,
                    ReceivedPoints = 0
                };
                _db.Add(checklistCriteria);
            }
            int result = await _db.SaveChangesAsync();
            return result > 0;
        }
    }
}
