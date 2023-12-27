using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;

namespace XFood.API.Pizzeria.Commands.DeletePizzeria
{
    public class DeletePizzeriaHandler : ICommandHandler<DeletePizzeriaRequest, Result<DeletePizzeriaResponse>>
    {
        private readonly XFoodContext _context;

        public DeletePizzeriaHandler(XFoodContext context)
        {
            _context = context;
        }

        public async Task<Result<DeletePizzeriaResponse>> Handle(DeletePizzeriaRequest command, CancellationToken cancellationToken)
        {
            XFood.Data.Models.Pizzeria pizzeria = await _context.Pizzerias.FindAsync(command.Id);

            if (pizzeria != null)
            {
                _context.Remove(pizzeria);
                await _context.SaveChangesAsync();
            }
            else 
            {
                return Result.Failure<DeletePizzeriaResponse>("Error! Failed to delete pizzeria");
            }
            return new DeletePizzeriaResponse(true);
        }
    }
}
