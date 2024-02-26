using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using XFood.API.Pizzeria.Queries.GetPizzeriaList;
using xFood.Infrastructure;
using XFood.API.OpportunitySchedule.Queries.GetScheduleList;

namespace XFood.API.OpportunitySchedule
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetScheduleListResponse))]
        public async Task<ActionResult<Result<GetPizzeriaListResponse>>> GetScheduleList(
            [FromQuery] GetScheduleListRequest request,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var res = await queryDispatcher.Dispatch<GetScheduleListRequest, Result<GetScheduleListResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
