using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.CriticalFactors.Commands.DeleteCriticalFactor
{
    public class DeleteCriticalFactorHandler : ICommandHandler<DeleteCriticalFactorRequest, Result<DeleteCriticalFactorResponse>>
    {
        private readonly XFoodContext _context;
        public DeleteCriticalFactorHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<DeleteCriticalFactorResponse>> Handle(DeleteCriticalFactorRequest command, CancellationToken cancellationToken)
        {
            CriticalFactor criticalFactor = await _context.CriticalFactors.FindAsync(command.Id);
            if (criticalFactor != null)
            {
                _context.Remove(criticalFactor);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Result.Failure<DeleteCriticalFactorResponse>("Error! Failed to delete criterion");
            }
            return new DeleteCriticalFactorResponse(true);
        }
    }
}
