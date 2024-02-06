using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.Appeal.Commands.Delete
{
    public class DeleteAppealHandler : ICommandHandler<DeleteAppealRequest, Result<DeleteAppealResponse>>
    {
        private readonly XFoodContext _context;
        public DeleteAppealHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<DeleteAppealResponse>> Handle(DeleteAppealRequest command, CancellationToken cancellationToken)
        {
            Data.Models.Appeal appeal = await _context.Appeals.FindAsync(command.Id);
            if (appeal != null)
            {
                _context.Remove(appeal);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Result.Failure<DeleteAppealResponse>("Error! Failed to delete criterion");
            }
            return new DeleteAppealResponse(true);
        }
    }
}
