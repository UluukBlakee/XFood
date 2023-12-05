using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using XFood.API.Employee.Queries.GetEmployeeList;
using xFood.Infrastructure;

namespace XFood.API.Employee;

[ApiController]
[Route("api/employee")]
public class EmployeeController : ControllerBase
{
    [HttpGet("list")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEmployeeListResponse))]
    public async Task<ActionResult<Result<GetEmployeeListResponse>>> GetEmployeeList(
        [FromQuery] GetEmployeeListRequest request,
        [FromServices] IQueryDispatcher queryDispatcher,
        CancellationToken cancellationToken
    )
    {
        var res = await queryDispatcher.Dispatch<GetEmployeeListRequest, Result<GetEmployeeListResponse>>(request, cancellationToken);

        return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
    }
}