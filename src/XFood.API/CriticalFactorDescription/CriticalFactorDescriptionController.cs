using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.CriticalFactors.Queries.GetCriticalFactorList;
using XFood.API.CriticalFactors.Commands.CreateCriticalFactor;
using XFood.API.CriticalFactors.Commands.EditCriticalFactor;
using XFood.API.CriticalFactors.Commands.DeleteCriticalFactor;
using XFood.API.CriticalFactorDescription.Queries.CriticalFactorDescriptionList;

namespace XFood.API.CriticalFactorDescription
{
    [ApiController]
    [Route("api/criticalFactorDescription")]
    public class CriticalFactorDescriptionController : Controller
    {
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CriticalFactorDescriptionListResponse))]
        public async Task<ActionResult<Result<CriticalFactorDescriptionListResponse>>> GetCriticalFactorDescriptionList(
        [FromQuery] CriticalFactorDescriptionListRequest request,
        [FromServices] IQueryDispatcher queryDispatcher,
        CancellationToken cancellationToken
    )
        {
            var res = await queryDispatcher.Dispatch<CriticalFactorDescriptionListRequest, Result<CriticalFactorDescriptionListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

    }
}