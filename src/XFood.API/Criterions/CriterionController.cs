using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.Account.Commands.AccountRegister;
using XFood.API.Criterions.Commands.DeleteCriterion;
using XFood.API.Criterions.Commands.PatchEditCriterion;
using XFood.API.Criterions.Commands.PostCreateCriterion;
using XFood.API.Criterions.Queries.GetCriterionList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace XFood.API.Criterions
{
    [ApiController]
    [Route("api/criterion")]
    public class CriterionController : Controller
    {
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCriterionListResponse))]
        public async Task<ActionResult<Result<GetCriterionListResponse>>> GetCriterionList(
        [FromQuery] GetCriterionListRequest request,
        [FromServices] IQueryDispatcher queryDispatcher,
        CancellationToken cancellationToken
    )
        {
            var res = await queryDispatcher.Dispatch<GetCriterionListRequest, Result<GetCriterionListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPost("create")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostCreateCriterionResponse))]
        public async Task<ActionResult<Result<PostCreateCriterionResponse>>> CreateCriterion(
        [FromBody] PostCreateCriterionRequest request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken cancellationToken
    )
        {
            var res = await commandDispatcher.Dispatch<PostCreateCriterionRequest, Result<PostCreateCriterionResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpPatch("edit/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatchEditCriterionResponse))]
        public async Task<ActionResult<Result<PatchEditCriterionResponse>>> EditCriterion(
        [FromRoute] int id,
        [FromBody] PatchEditCriterionRequest request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken cancellationToken
    )
        {
            var newRequest = request with { Id = id };
            var res = await commandDispatcher.Dispatch<PatchEditCriterionRequest, Result<PatchEditCriterionResponse>>(newRequest, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCriterionResponse))]
        public async Task<ActionResult<Result<DeleteCriterionResponse>>> DeleteCriterion(
        [FromRoute] int id,
        [FromBody] DeleteCriterionRequest request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken cancellationToken
    )
        {
            var newRequest = request with { Id = id };
            var res = await commandDispatcher.Dispatch<DeleteCriterionRequest, Result<DeleteCriterionResponse>>(newRequest, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
