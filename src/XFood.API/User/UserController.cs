using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.User.Queries.GetList;
using XFood.API.User.Queries.GetUser;

namespace XFood.API.User
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserListResponse))]
        public async Task<ActionResult<Result<GetUserListResponse>>> GetManagersList(
        [FromQuery] GetUserListRequest request,
        [FromServices] IQueryDispatcher queryDispatcher,
        CancellationToken cancellationToken
)
        {
            var res = await queryDispatcher.Dispatch<GetUserListRequest, Result<GetUserListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserResponse))]
        public async Task<ActionResult<Result<GetUserRequest>>> GetUser(
            [FromRoute] int id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var request = new GetUserRequest(id);
            var res = await queryDispatcher.Dispatch<GetUserRequest, Result<GetUserResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

    }
}
