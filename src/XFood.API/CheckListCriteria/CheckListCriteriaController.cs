using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.CheckListCriteria.Commands.SetPoints;

namespace XFood.API.CheckListCriteria
{
    [Route("api/checkListCriteria")]
    [ApiController]
    public class CheckListCriteriaController : ControllerBase
    {
        [HttpPost("setPoints")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SetPointsResponse))]
        public async Task<ActionResult<Result<SetPointsResponse>>> SetPoints(
           [FromBody] SetPointsRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var res = await commandDispatcher.Dispatch<SetPointsRequest, Result<SetPointsResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
