using CSharpFunctionalExtensions;
using xFood.Infrastructure;

namespace XFood.API.Criterions.Queries.GetCriterionList;

public class GetCriterionListHandler : IQueryHandler<GetCriterionListRequest, Result<GetCriterionListResponse>>
{
    public async Task<Result<GetCriterionListResponse>> Handle(GetCriterionListRequest query,
        CancellationToken cancellation)
    {
        return new GetCriterionListResponse(new List<CriterionView>
        {
            new CriterionView { Name = "Criterion1" },
            new CriterionView { Name = "Criterion2" },
            new CriterionView { Name = "Criterion3" },
            new CriterionView { Name = "Criterion4" },
            new CriterionView { Name = "Criterion5" },
        });
    }
}