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
                Data.Models.User user = await _db.Users.FirstOrDefaultAsync(u =>u.Id == command.UserId);
                List<Criterion> criteriaList = await _db.Criteria
                    .Where(c => c.PizzeriaId == manager.PizzeriaId)
                    .ToListAsync();

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
                await _db.AddAsync(newCheckList);
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    List<CheckListCriteriaView> checkListCriteria = new List<CheckListCriteriaView>();
                    foreach (var criterion in criteriaList)
                    {
                        ChecklistCriteria checklistCriteria = new ChecklistCriteria
                        {
                            CheckListId = newCheckList.Id,
                            CriterionId = criterion.Id,
                            ReceivedPoints = 0
                        };
                        await _db.AddAsync(checklistCriteria);
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
                    CheckListView checkList = new CheckListView
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
                    return new CreateCheckListResponse(checkList);
                }
                else
                {
                    return Result.Failure<CreateCheckListResponse>("Не удалось сохранить изменения в базе данных.");
                }
            }
            catch (Exception ex)
            {
                return Result.Failure<CreateCheckListResponse>($"Произошла ошибка: {ex.Message}");
            }
        }

    }
}
