using ChatApp.Application.Features.User.Commands;
using ChatApp.Application.Features.User.Commands.Login;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security;

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

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto entity)
        {
            try
            {
                var registerCommand = new LoginUserCommand(entity);

                var token = await _mediator.Send(registerCommand);

                return StatusCode(StatusCodes.Status201Created, token);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (ValidationException ex)
            {
                return Conflict(new { errors = ex.Errors.Select(e => e.ErrorMessage) });
            }
            catch (SecurityException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("/users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                // Test JWT token
                return Ok("Hello");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

    }
}
