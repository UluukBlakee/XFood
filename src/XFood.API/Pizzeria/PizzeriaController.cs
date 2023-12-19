using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.Pizzeria.Commands.CreatePizzeria;
using XFood.API.Pizzeria.Commands.DeletePizzeria;
using XFood.API.Pizzeria.Commands.UpdatePizzeria;
using XFood.API.Pizzeria.Queries.GetPizzeria;
using XFood.API.Pizzeria.Queries.GetPizzeriaList;

namespace XFood.API.Pizzeria
{
    [ApiController]
    [Route("api/pizzeria")]
    public class PizzeriaController : ControllerBase
    {
        
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPizzeriaListResponse))]
        public async Task<ActionResult<Result<GetPizzeriaListResponse>>> GetPizzeriList(
            [FromQuery] GetPizzeriaListRequest request,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var res = await queryDispatcher.Dispatch<GetPizzeriaListRequest, Result<GetPizzeriaListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPizzeriaResponse))]
        public async Task<ActionResult<Result<GetPizzeriaResponse>>> GetPizzeria(
            [FromRoute] int id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var request = new GetPizzeriaRequest(id);
            var res = await queryDispatcher.Dispatch<GetPizzeriaRequest, Result<GetPizzeriaResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatePizzeriaResponse))]
        public async Task<ActionResult<Result<CreatePizzeriaResponse>>> Create(
           [FromBody] CreatePizzeriaRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var res = await commandDispatcher.Dispatch<CreatePizzeriaRequest, Result<CreatePizzeriaResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatePizzeriaResponse))]
        public async Task<ActionResult<Result<UpdatePizzeriaResponse>>> Update(
           [FromRoute] int id,
           [FromBody] UpdatePizzeriaRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            request.Id = id;
            var res = await commandDispatcher.Dispatch<UpdatePizzeriaRequest, Result<UpdatePizzeriaResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeletePizzeriaResponse))]
        public async Task<ActionResult<Result<DeletePizzeriaResponse>>> Delete(
           [FromRoute] int id,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var request = new DeletePizzeriaRequest(id);
            var res = await commandDispatcher.Dispatch<DeletePizzeriaRequest, Result<DeletePizzeriaResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
