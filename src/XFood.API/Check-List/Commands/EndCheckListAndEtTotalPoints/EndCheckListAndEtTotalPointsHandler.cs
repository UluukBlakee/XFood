using CSharpFunctionalExtensions;
using XFood.API.Check_List.Commands.UpdateCheckList;
using xFood.Infrastructure;
using XFood.Data.Models;
using XFood.Data;
using Microsoft.EntityFrameworkCore;
using XFood.API.Criterions.Commands.PatchEditCriterion;

namespace XFood.API.Check_List.Commands.EndCheckListAndEtTotalPoints
{
    public class EndCheckListAndEtTotalPointsHandler : ICommandHandler<EndCheckListAndEtTotalPointsRequest, Result<EndCheckListAndEtTotalPointsResponse>>
    {
        private readonly XFoodContext _context;
        public EndCheckListAndEtTotalPointsHandler(XFoodContext context)
        {
            _context = context;
        }
        public async Task<Result<EndCheckListAndEtTotalPointsResponse>> Handle(EndCheckListAndEtTotalPointsRequest command, CancellationToken cancellationToken)
        {
            CheckList checkList = await _context.CheckLists.FindAsync(command.Id);
            if (checkList != null)
            {
                checkList.TotalPoints = command.TotalPoints;
                checkList.EndCheck = command.EndCheck;
                checkList.Status = command.Status;
                _context.Update(checkList);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Result.Failure<EndCheckListAndEtTotalPointsResponse>("Error!");
            }
            return new EndCheckListAndEtTotalPointsResponse(true);
        }
    }
}
