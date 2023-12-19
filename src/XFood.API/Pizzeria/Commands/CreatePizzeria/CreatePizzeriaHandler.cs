using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.Pizzeria.Commands.CreatePizzeria
{
    public class CreatePizzeriaHandler : ICommandHandler<CreatePizzeriaRequest, Result<CreatePizzeriaResponse>>
    {
        private readonly XFoodContext _context;
        public CreatePizzeriaHandler(XFoodContext context)
        {
            _context = context;
        }

        public async Task<Result<CreatePizzeriaResponse>> Handle(CreatePizzeriaRequest command, CancellationToken cancellationToken)
        {
            var newPizzeria = new XFood.Data.Models.Pizzeria { Name = command.Name, Region = command.Region };
            var result = await _context.AddAsync(newPizzeria);
            await _context.SaveChangesAsync();
            
            if (result.Entity == null)
            {
                return Result.Failure<CreatePizzeriaResponse>("Error! Failed to add new pizzeria");
            }
            return new CreatePizzeriaResponse(true);
        }
    }
}
