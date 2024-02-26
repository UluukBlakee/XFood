using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.CriticalFactors.Queries.GetCriticalFactorList;
using XFood.API.CriticalFactors.Commands.CreateCriticalFactor;
using XFood.API.CriticalFactors.Commands.EditCriticalFactor;
using XFood.API.CriticalFactors.Commands.DeleteCriticalFactor;

namespace XFood.API.CriticalFactors
{
    [ApiController]
    [Route("api/criticalFactor")]
    public class CriticalFactorController : Controller
    {
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCriticalFactorListResponse))]
        public async Task<ActionResult<Result<GetCriticalFactorListResponse>>> GetCriticalFactorList(
        [FromQuery] GetCriticalFactorListRequest request,
        [FromServices] IQueryDispatcher queryDispatcher,
        CancellationToken cancellationToken
    )
        {
            var res = await queryDispatcher.Dispatch<GetCriticalFactorListRequest, Result<GetCriticalFactorListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateScheduleResponse))]
        public async Task<ActionResult<Result<CreateScheduleResponse>>> CreateCriticalFactor(
        [FromBody] CreateCriticalFactorRequest request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken cancellationToken
    )
        {
            var res = await commandDispatcher.Dispatch<CreateCriticalFactorRequest, Result<CreateScheduleResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EditCriticalFactorResponse))]
        public async Task<ActionResult<Result<EditCriticalFactorResponse>>> EditCriticalFactor(
        [FromRoute] int id,
        [FromBody] EditCriticalFactorRequest request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken cancellationToken
    )
        {
            request.Id = id;
            var res = await commandDispatcher.Dispatch<EditCriticalFactorRequest, Result<EditCriticalFactorResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCriticalFactorResponse))]
        public async Task<ActionResult<Result<DeleteCriticalFactorResponse>>> DeleteCriticalFactor(
        [FromRoute] int id,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken cancellationToken
    )
        {
            var newRequest = new DeleteCriticalFactorRequest(id);
            var res = await commandDispatcher.Dispatch<DeleteCriticalFactorRequest, Result<DeleteCriticalFactorResponse>>(newRequest, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}