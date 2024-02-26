using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xFood.Infrastructure;
using XFood.API.Photos.Commands.Create;

namespace XFood.API.Photos
{
    [Route("api/photo")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        [HttpPost("")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatePhotoResponse))]
        public async Task<ActionResult<Result<CreatePhotoResponse>>> Create(
           [FromForm] CreatePhotoRequest request,
           [FromServices] ICommandDispatcher commandDispatcher,
           CancellationToken cancellationToken
        )
        {
            var res = await commandDispatcher.Dispatch<CreatePhotoRequest, Result<CreatePhotoResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
