using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using XFood.API.Pizzeria.Queries.GetPizzeriaList;
using xFood.Infrastructure;


namespace XFood.API.Time
{
    [ApiController]
    [Route("api/time")]
    public class TimeController
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
    }
}
