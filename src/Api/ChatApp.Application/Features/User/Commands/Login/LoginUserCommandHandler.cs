using ChatApp.Application.Service.Interfaces;
using ChatApp.Infrastructure;
using ChatApp.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using System.Security;

namespace ChatApp.Application.Features.User.Commands.Login
{
    public class LoginUserCommandHandler(IUserRepository _userRepository, IValidator<LoginUserDto> _validator, 
        IPasswordService _passwordService, IUnitOfWork _unitOfWork, ITokenService _tokenService)
        : IRequestHandler<LoginUserCommand, string>
    {
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var entity = request.entity;

            var validationResult = await _validator.ValidateAsync(entity, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var entityDb = await _userRepository.GetByEmailAsync(entity.Email);

            if (entityDb == null)
                throw new ArgumentNullException("User not found with email: " + entity.Email);

            if (!_passwordService.Verify(entity.Password, entityDb.Password))
                throw new SecurityException("Invalid password.");

            await _userRepository.UpdateLastLoginAsync(entityDb.Id);

            await _unitOfWork.SaveChangesAsync();

            return _tokenService.CreateToken(entityDb) ?? throw new ArgumentNullException("Couldn't create token");
        }
    }
}
