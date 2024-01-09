using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.CheckListCriteria.Commands.SetPoints
{
    public class SetPointsHandler : ICommandHandler<SetPointsRequest, Result<SetPointsResponse>>
    {
        private readonly XFoodContext _db;

        public SetPointsHandler(XFoodContext context)
        {
            _db = context;
        }
        public async Task<Result<SetPointsResponse>> Handle(SetPointsRequest command, CancellationToken cancellationToken)
        {
            ChecklistCriteria criteria = await _db.ChecklistCriteria.FirstOrDefaultAsync(c => c.Id == command.Id);
            if (criteria != null)
            {
                criteria.ReceivedPoints = command.ReceivedPoints;
                _db.Update(criteria);
                await _db.SaveChangesAsync();
                return new SetPointsResponse(true);
            }
            return new SetPointsResponse(false);
        }
    }
}
