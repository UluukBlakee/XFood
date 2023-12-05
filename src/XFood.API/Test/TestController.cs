using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using XFood.API.Test.Queries;
using XFood.API.Test.Queries.GetTestData;
using xFood.Infrastructure;

namespace XFood.API.Test;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet("list")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTestDataResponse))]
    public async Task<ActionResult<Result<GetTestDataResponse>>> GetTestDataResponse(
        [FromQuery] GetTestDataRequest request,
        [FromServices] IQueryDispatcher queryDispatcher,
        CancellationToken cancellationToken
    )
    {
        var result =
            await queryDispatcher.Dispatch<GetTestDataRequest, Result<GetTestDataResponse>>(request, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}