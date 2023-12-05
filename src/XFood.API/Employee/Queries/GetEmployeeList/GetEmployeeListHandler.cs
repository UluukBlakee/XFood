using CSharpFunctionalExtensions;
using xFood.Infrastructure;

namespace XFood.API.Employee.Queries.GetEmployeeList;

public class GetEmployeeListHandler : IQueryHandler<GetEmployeeListRequest, Result<GetEmployeeListResponse>>
{
    public async Task<Result<GetEmployeeListResponse>> Handle(GetEmployeeListRequest query,
        CancellationToken cancellation)
    {
        return new GetEmployeeListResponse(new List<EmployeeView>
        {
            new EmployeeView { Name = "Vladimir" },
            new EmployeeView { Name = "Vladimir" },
            new EmployeeView { Name = "Vladimir" },
            new EmployeeView { Name = "Vladimir" },
            new EmployeeView { Name = "Vladimir" },
        });
    }
}