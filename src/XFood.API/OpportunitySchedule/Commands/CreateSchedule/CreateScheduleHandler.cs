using CSharpFunctionalExtensions;
using XFood.API.Criterions.Commands.PostCreateCriterion;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.CriticalFactors.Commands.CreateCriticalFactor
{
    public class CreateScheduleHandler : ICommandHandler<CreateScheduleRequest, Result<CreateScheduleResponse>>
    {
        private readonly XFoodContext _context;
        public CreateScheduleHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<CreateScheduleResponse>> Handle(CreateScheduleRequest command, CancellationToken cancellationToken)
        {
            var newSchedule = new OpportunitySchedule { MaxPoints = command.MaxPoints, Description = command.Description, CriterionId = command.CriterionId, CheckListId = command.CheckListId};
            var result = await _context.AddAsync(newSchedule);
            await _context.SaveChangesAsync();
            if (result.Entity == null)
            {
                return Result.Failure<CreateScheduleResponse>("Error! Failed to add new criterion");
            }
            return new CreateScheduleResponse(true);
        }
    }
}
