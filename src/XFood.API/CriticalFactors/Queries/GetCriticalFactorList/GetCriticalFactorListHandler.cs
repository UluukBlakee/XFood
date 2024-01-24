using CSharpFunctionalExtensions;
using xFood.Infrastructure;

namespace XFood.API.CriticalFactors.Queries.GetCriticalFactorList;

public class GetCriticalFactorListHandler : IQueryHandler<GetCriticalFactorListRequest, Result<GetCriticalFactorListResponse>>
{
    public async Task<Result<GetCriticalFactorListResponse>> Handle(GetCriticalFactorListRequest query, CancellationToken cancellation)
    {
        return new GetCriticalFactorListResponse(new List<CriticalFactorView>
        {
            new CriticalFactorView { Description = "CriticalFactor1" },
            new CriticalFactorView { Description = "CriticalFactor2" },
            new CriticalFactorView { Description = "CriticalFactor3" },
            new CriticalFactorView { Description = "CriticalFactor4" },
            new CriticalFactorView { Description = "CriticalFactor5" },
        });
    }
}
