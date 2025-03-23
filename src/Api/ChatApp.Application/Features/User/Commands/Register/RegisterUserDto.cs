namespace ChatApp.Application.Features.User.Commands;
public record RegisterUserDto (
    string Username,
    string Firstname,
    string Lastname,
    string Adress,
    string Email,
    string Password,
    DateTime BirthDate
    );
