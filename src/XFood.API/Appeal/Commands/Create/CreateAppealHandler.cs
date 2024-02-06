using CSharpFunctionalExtensions;
using XFood.Data.Models;
using XFood.Data;
using xFood.Infrastructure;

namespace XFood.API.Appeal.Commands.Create
{
    public class CreateAppealHandler : ICommandHandler<CreateAppealRequest, Result<CreateAppealResponse>>
    {
        private readonly XFoodContext _context;
        public CreateAppealHandler(XFoodContext context)
        {
            _context = context;
        }

        public async Task<Result<CreateAppealResponse>> Handle(CreateAppealRequest command, CancellationToken cancellationToken)
        {
            var appeal = new Data.Models.Appeal { Email = command.Email, Description = command.Description, Materials = command.Materials, ChecklistCriteriaId = command.ChecklistCriteriaId, CheckListId = command.CheckListId, IsApproved = false };
            var result = await _context.AddAsync(appeal);
            await _context.SaveChangesAsync();
            if (result.Entity == null)
            {
                return Result.Failure<CreateAppealResponse>("Error! Failed to add new criterion");
            }
            return new CreateAppealResponse(appeal.Id);
        }
    }
}
