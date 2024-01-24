using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.CriticalFactors.Commands.EditCriticalFactor
{
    public class EditCriticalFactorHandler : ICommandHandler<EditCriticalFactorRequest, Result<EditCriticalFactorResponse>>
    {
        private readonly XFoodContext _context;
        public EditCriticalFactorHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<EditCriticalFactorResponse>> Handle(EditCriticalFactorRequest command, CancellationToken cancellationToken)
        {
            CriticalFactor criticalFactor = await _context.CriticalFactors.FindAsync(command.Id);
            if (criticalFactor != null)
            {
                criticalFactor.MaxPoints = command.MaxPoints;
                criticalFactor.Description = command.Description;
                _context.Update(criticalFactor);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Result.Failure<EditCriticalFactorResponse>("Error! Failed to update criterion");
            }
            return new EditCriticalFactorResponse(true);
        }
    }
}
