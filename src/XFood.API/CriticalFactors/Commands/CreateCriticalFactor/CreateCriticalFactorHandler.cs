﻿using CSharpFunctionalExtensions;
using XFood.API.Criterions.Commands.PostCreateCriterion;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.CriticalFactors.Commands.CreateCriticalFactor
{
    public class CreateCriticalFactorHandler : ICommandHandler<CreateCriticalFactorRequest, Result<CreateCriticalFactorResponse>>
    {
        private readonly XFoodContext _context;
        public CreateCriticalFactorHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<CreateCriticalFactorResponse>> Handle(CreateCriticalFactorRequest command, CancellationToken cancellationToken)
        {
            var newCriticalFactor = new CriticalFactor { MaxPoints = command.MaxPoints, Description = command.Description, CriterionId = command.CriterionId };
            var result = await _context.AddAsync(newCriticalFactor);
            await _context.SaveChangesAsync();
            if (result.Entity == null)
            {
                return Result.Failure<CreateCriticalFactorResponse>("Error! Failed to add new criterion");
            }
            return new CreateCriticalFactorResponse(true);
        }
    }
}
