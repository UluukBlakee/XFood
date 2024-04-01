using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
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
            var criticalFactor = await _context.CriticalFactors.Include(cf => cf.Descriptions)
                                                        .FirstOrDefaultAsync(cf => cf.Id == command.Id);

            if (criticalFactor == null)
            {
                return Result.Failure<EditCriticalFactorResponse>("Critical factor not found");
            }
            _context.CriticalFactorDescriptions.RemoveRange(criticalFactor.Descriptions);
            var descriptions = command.Descriptions.Select(d => new XFood.Data.Models.CriticalFactorDescription
            {
                Description = d.Description
            }).ToList();
            criticalFactor.Descriptions.AddRange(descriptions);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return Result.Failure<EditCriticalFactorResponse>("Error! Failed to update critical factor");
            }

            return new EditCriticalFactorResponse(true);
        }

    }
}
