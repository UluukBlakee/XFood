using CSharpFunctionalExtensions;
using xFood.Infrastructure;

namespace XFood.API.Test.Queries.GetTestData;

public class GetTestDataHandler : IQueryHandler<GetTestDataRequest, Result<GetTestDataResponse>>
{
    public async Task<Result<GetTestDataResponse>> Handle(GetTestDataRequest query, CancellationToken cancellation)
    {
        return new GetTestDataResponse(new List<TestDataView>
        {
            new TestDataView { Data = "1" },
            new TestDataView { Data = "2" },
            new TestDataView { Data = "3" },
            new TestDataView { Data = "4" },
            new TestDataView { Data = "5" },
            new TestDataView { Data = "6" },
        });
    }
}