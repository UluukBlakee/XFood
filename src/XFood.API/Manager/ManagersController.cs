using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.Manager.Commands.CreateManager;
using XFood.API.Manager.Commands.DeleteManager;
using XFood.API.Manager.Commands.UpdateManager;
using XFood.API.Manager.Queries.GetManager;
using XFood.API.Manager.Queries.GetManagersList;

namespace XFood.API.Manager
{
    [Route("api/manager")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetManagersListResponse))]
        public async Task<ActionResult<Result<GetManagersListResponse>>> GetManagersList(
            [FromQuery] GetManagersListRequest request,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var res = await queryDispatcher.Dispatch<GetManagersListRequest, Result<GetManagersListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetManagerResponse))]
        public async Task<ActionResult<Result<GetManagerResponse>>> GetManager(
            [FromRoute] int id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var request = new GetManagerRequest(id);
            var res = await queryDispatcher.Dispatch<GetManagerRequest, Result<GetManagerResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateManagerResponse))]
        public async Task<ActionResult<Result<CreateManagerResponse>>> Create(
           [FromBody] CreateManagerRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var res = await commandDispatcher.Dispatch<CreateManagerRequest, Result<CreateManagerResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateManagerResponse))]
        public async Task<ActionResult<Result<UpdateManagerResponse>>> Update(
           [FromRoute] int id,
           [FromBody] UpdateManagerRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            request.Id = id;
            var res = await commandDispatcher.Dispatch<UpdateManagerRequest, Result<UpdateManagerResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteManagerResponse))]
        public async Task<ActionResult<Result<DeleteManagerResponse>>> Delete(
           [FromRoute] int id,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var request = new DeleteManagerRequest(id);
            var res = await commandDispatcher.Dispatch<DeleteManagerRequest, Result<DeleteManagerResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
