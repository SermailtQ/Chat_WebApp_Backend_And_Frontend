using ChatApp.Application.Features.User.Commands;
using FluentValidation;

namespace ChatApp.Application.Validators
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Password is required")
                    .MinimumLength(8).WithMessage("Password must be at least 8 characters")
                    .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                    .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                    .Matches(@"\d").WithMessage("Password must contain at least one number")
                    .Matches(@"[!@#$%^&*(),.?""{}|<>]").WithMessage("Password must contain at least one special character (!@#$%^&*)")
                    .Must(NotContainWhitespace).WithMessage("Password cannot contain spaces");
        }

        private bool NotContainWhitespace(string password) => !string.IsNullOrWhiteSpace(password);
    }
}
