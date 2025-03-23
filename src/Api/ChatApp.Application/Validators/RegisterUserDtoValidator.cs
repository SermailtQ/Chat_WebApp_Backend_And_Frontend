using ChatApp.Application.Features.User.Commands;
using FluentValidation;

namespace ChatApp.Application.Validators;
public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator()
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

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(5).WithMessage("Username must be at least 5 characters")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Username can only contain letters and numbers"); ;

        RuleFor(x => x.Firstname)
            .NotEmpty().WithMessage("Firstname is required")
            .MinimumLength(1).WithMessage("Firstname must be at least 1 character");

        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage("Lastname is required")
            .MinimumLength(1).WithMessage("Lastname must be at least 1 character");

    }

    private bool NotContainWhitespace(string password) => !string.IsNullOrWhiteSpace(password);

}
