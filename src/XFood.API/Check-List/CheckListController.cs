using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using xFood.Infrastructure;
using XFood.API.Check_List.Commands.CreateCheckList;
using XFood.API.Check_List.Commands.DeleteCheckList;
using XFood.API.Check_List.Commands.UpdateCheckList;
using XFood.API.Check_List.Queries.GetCheckList;
using XFood.API.Check_List.Queries.GetCheckListAll;

namespace XFood.API.Check_List
{
    [Route("api/checkList")]
    [ApiController]
    public class CheckListController : ControllerBase
    {
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCheckListAllResponse))]
        public async Task<ActionResult<Result<GetCheckListAllResponse>>> GetCheckListAll(
            [FromQuery] GetCheckListAllRequest request,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var res = await queryDispatcher.Dispatch<GetCheckListAllRequest, Result<GetCheckListAllResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCheckListResponse))]
        public async Task<ActionResult<Result<GetCheckListResponse>>> GetCheckList(
            [FromRoute] int id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var request = new GetCheckListRequest(id);
            var res = await queryDispatcher.Dispatch<GetCheckListRequest, Result<GetCheckListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCheckListResponse))]
        public async Task<ActionResult<Result<CreateCheckListResponse>>> Create(
           [FromBody] CreateCheckListRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var res = await commandDispatcher.Dispatch<CreateCheckListRequest, Result<CreateCheckListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateCheckListResponse))]
        public async Task<ActionResult<Result<UpdateCheckListResponse>>> Update(
           [FromRoute] int id,
           [FromBody] UpdateCheckListRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            request.Id = id;
            var res = await commandDispatcher.Dispatch<UpdateCheckListRequest, Result<UpdateCheckListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCheckListResponse))]
        public async Task<ActionResult<Result<DeleteCheckListResponse>>> Delete(
           [FromRoute] int id,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var request = new DeleteCheckListRequest(id);
            var res = await commandDispatcher.Dispatch<DeleteCheckListRequest, Result<DeleteCheckListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
