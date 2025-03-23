using MediatR;

namespace ChatApp.Application.Features.User.Commands
{
    public record RegisterUserCommand(RegisterUserDto entity) : IRequest;
}
