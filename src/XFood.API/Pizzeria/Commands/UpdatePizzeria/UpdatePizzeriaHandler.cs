using CSharpFunctionalExtensions;
using XFood.API.Criterions.Commands.PostCreateCriterion;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;
using Microsoft.AspNetCore.Mvc;

namespace XFood.API.Pizzeria.Commands.UpdatePizzeria
{
    public class UpdatePizzeriaHandler : ICommandHandler<UpdatePizzeriaRequest, Result<UpdatePizzeriaResponse>>
    {
        private readonly XFoodContext _context;

        public UpdatePizzeriaHandler(XFoodContext context)
        {
            _context = context;
        }

        public async Task<Result<UpdatePizzeriaResponse>> Handle(UpdatePizzeriaRequest command, CancellationToken cancellationToken)
        {
            XFood.Data.Models.Pizzeria pizzeria = await _context.Pizzerias.FindAsync(command.Id);

            if (pizzeria != null)
            {
                pizzeria.Name = command.Name;
                pizzeria.Region = command.Region;
                _context.Update(pizzeria);
                await _context.SaveChangesAsync();
            }
            else 
            {
                return Result.Failure<UpdatePizzeriaResponse>("Error! Failed to update pizzeria");
            }
            return new UpdatePizzeriaResponse(true);
        }
    }
}
