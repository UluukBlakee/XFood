using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using xFood.Infrastructure;
using XFood.API.Check_List.Queries.GetCheckListAll;
using XFood.API.Pizzeria.Queries.GetPizzeriaList;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.CriticalFactors.Queries.GetCriticalFactorList;

public class GetCriticalFactorListHandler : IQueryHandler<GetCriticalFactorListRequest, Result<GetCriticalFactorListResponse>>
{
    private readonly XFoodContext _db;
    public GetCriticalFactorListHandler(XFoodContext context)
    {
        _db = context;
    }

    public async Task<Result<GetCriticalFactorListResponse>> Handle(GetCriticalFactorListRequest query, CancellationToken cancellation)
    {
        List<XFood.Data.Models.CriticalFactor> criticalFactors = await _db.CriticalFactors.ToListAsync();
        List<CriticalFactorView> list = criticalFactors.Select(c => new CriticalFactorView
        {
            Id = c.Id,
            CriterionId = c.CriterionId,
            Description = c.Description,
            MaxPoints = c.MaxPoints,
            CheckListId = c.CheckListId,
        }).ToList();
        return new GetCriticalFactorListResponse(list);
    }
}
