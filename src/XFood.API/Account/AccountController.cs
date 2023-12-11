﻿using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using XFood.API.Employee.Queries.GetEmployeeList;
using xFood.Infrastructure;
using XFood.API.Account.Commands.AccountRegister;

namespace XFood.API.Account
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        [HttpPost("register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountRegisterResponse))]
        public async Task<ActionResult<Result<AccountRegisterResponse>>> GetEmployeeList(
        [FromBody] AccountRegisterRequest request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken cancellationToken
    )
        {
            var res = await commandDispatcher.Dispatch<AccountRegisterRequest, Result<AccountRegisterResponse>>(request, cancellationToken);

            return res.IsSuccess ? Ok(res.Value) : BadRequest(res.Error);
        }
    }
}
