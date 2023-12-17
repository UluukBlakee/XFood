using CSharpFunctionalExtensions;
using XFood.API.Criterions.Commands.PostCreateCriterion;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;
using Microsoft.AspNetCore.Mvc;

namespace XFood.API.Criterions.Commands.PatchEditCriterion
{
    public class PatchEditCriterionHandler : ICommandHandler<PatchEditCriterionRequest, Result<PatchEditCriterionResponse>>
    {
        private readonly XFoodContext _context;
        public PatchEditCriterionHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<PatchEditCriterionResponse>> Handle(PatchEditCriterionRequest command, CancellationToken cancellationToken)
        {
            Criterion criterion = await _context.Criteria.FindAsync(command.Id);
            if (criterion != null)
            {
                criterion.Name = command.Name;
                criterion.MaxPoints = command.MaxPoints;
                criterion.Section = command.Section;
                criterion.ReceivedPoints = command.ReceivedPoints;
                criterion.CheckListId = command.CheckListId;
                _context.Update(criterion);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Result.Failure<PatchEditCriterionResponse>("Error! Failed to update criterion");
            }
            return new PatchEditCriterionResponse(true);
        }
    }
}
