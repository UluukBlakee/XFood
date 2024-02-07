using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.Appeal.Commands.Create;
using XFood.API.Appeal.Commands.Delete;
using XFood.API.Appeal.Queries.GetAppeal;
using XFood.API.Appeal.Queries.GetListAppeals;

namespace XFood.API.Appeal
{
    [Route("api/appeal")]
    [ApiController]
    public class AppealsController : ControllerBase
    {
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetListAppealsResponse))]
        public async Task<ActionResult<Result<GetListAppealsResponse>>> GetListAppeals(
           [FromQuery] GetListAppealsRequest request,
           [FromServices] IQueryDispatcher queryDispatcher,
           CancellationToken cancellationToken
       )
        {
            var res = await queryDispatcher.Dispatch<GetListAppealsRequest, Result<GetListAppealsResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAppealResponse))]
        public async Task<ActionResult<Result<GetAppealResponse>>> GetAppeal(
            [FromRoute] int id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var request = new GetAppealRequest(id);
            var res = await queryDispatcher.Dispatch<GetAppealRequest, Result<GetAppealResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateAppealResponse))]
        public async Task<ActionResult<Result<CreateAppealResponse>>> Create(
           [FromBody] CreateAppealRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var res = await commandDispatcher.Dispatch<CreateAppealRequest, Result<CreateAppealResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteAppealResponse))]
        public async Task<ActionResult<Result<DeleteAppealResponse>>> Delete(
           [FromRoute] int id,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var request = new DeleteAppealRequest(id);
            var res = await commandDispatcher.Dispatch<DeleteAppealRequest, Result<DeleteAppealResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
 