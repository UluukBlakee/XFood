using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;
using XFood.API.CriticalFactorDescription.Queries.CriticalFactorDescriptionList;

namespace XFood.API.CriticalFactorDescription.Queries.CriticalFactorDescriptionList
{
    public class CriticalFactorDescriptionListHandler :  IQueryHandler<CriticalFactorDescriptionListRequest, Result<CriticalFactorDescriptionListResponse>>
    {
        private readonly XFoodContext _db;
        public CriticalFactorDescriptionListHandler(XFoodContext context)
        {
            _db = context;
        }

        public async Task<Result<CriticalFactorDescriptionListResponse>> Handle(CriticalFactorDescriptionListRequest query, CancellationToken cancellation)
        {
            List<XFood.Data.Models.CriticalFactorDescription> criticalFactorsDescriptions = await _db.CriticalFactorDescriptions.ToListAsync();
            List<CriticalFactorDescriptionView> list = criticalFactorsDescriptions.Select(c => new CriticalFactorDescriptionView
            {
                Id = c.Id,
                CriticalFactorId = c.Id,
                Description = c.Description,
            }).ToList();
            return new CriticalFactorDescriptionListResponse(list);
        }
    }
}