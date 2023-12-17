using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;

namespace XFood.API.Criterions.Commands.DeleteCriterion
{
    public class DeleteCriterionHandler : ICommandHandler<DeleteCriterionRequest, Result<DeleteCriterionResponse>>
    {
        private readonly XFoodContext _context;
        public DeleteCriterionHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<DeleteCriterionResponse>> Handle(DeleteCriterionRequest command, CancellationToken cancellationToken)
        {
            Criterion criterion = await _context.Criteria.FindAsync(command.Id);
            if (criterion != null)
            {
                _context.Remove(criterion);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Result.Failure<DeleteCriterionResponse>("Error! Failed to delete criterion");
            }
            return new DeleteCriterionResponse(true);
        }
    }
}
