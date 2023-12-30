using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.Criterions.Commands.PostCreateCriterion
{
    public class PostCreateCriterionHandler : ICommandHandler<PostCreateCriterionRequest, Result<PostCreateCriterionResponse>>
    {
        private readonly XFoodContext _context;
        public PostCreateCriterionHandler(XFoodContext context)
        {
            _context = context;
        }

        public async Task<Result<PostCreateCriterionResponse>> Handle(PostCreateCriterionRequest command, CancellationToken cancellationToken)
        {
            var newCriterion = new Criterion { Name = command.Name, MaxPoints = command.MaxPoints, Section = command.Section, PizzeriaId = command.PizzeriaId };
            var result = await _context.AddAsync(newCriterion);
            await _context.SaveChangesAsync();
            if (result.Entity == null)
            {
                return Result.Failure<PostCreateCriterionResponse>("Error! Failed to add new criterion");
            }
            return new PostCreateCriterionResponse(true);
        }
    }
}
