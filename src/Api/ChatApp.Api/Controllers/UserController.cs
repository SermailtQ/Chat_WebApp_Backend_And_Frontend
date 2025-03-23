using ChatApp.Application.Features.User.Commands;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto entity)
        {
            try
            {
                var registerCommand = new RegisterUserCommand(entity);

                await _mediator.Send(registerCommand);

                return StatusCode(StatusCodes.Status201Created, "User registered successfully");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (ValidationException ex)
            {
                return Conflict(new { errors = ex.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
