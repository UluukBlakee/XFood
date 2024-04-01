using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using xFood.Infrastructure;
using XFood.API.Check_List.Queries.GetCheckListAll;
using XFood.API.CriticalFactorDescription.Queries;
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
        List<XFood.Data.Models.CriticalFactor> criticalFactors = await _db.CriticalFactors.Include(c => c.Descriptions).ToListAsync();

        List<CriticalFactorView> list = criticalFactors.Select(c => new CriticalFactorView
        {
            Id = c.Id,
            CriterionId = c.CriterionId,
            MaxPoints = c.MaxPoints,
            Descriptions = c.Descriptions.Select(d => new CriticalFactorDescriptionView
            {
                Id = d.Id,
                CriticalFactorId = d.CriticalFactorId,
                Description = d.Description,
            }).ToList()
        }).ToList();

        return new GetCriticalFactorListResponse(list);
    }

}
