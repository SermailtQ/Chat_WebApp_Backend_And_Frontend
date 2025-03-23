using MediatR;

namespace ChatApp.Application.Features.User.Commands.Login
{
    public record LoginUserCommand(LoginUserDto entity) : IRequest<string>;
}
