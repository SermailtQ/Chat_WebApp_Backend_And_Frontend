using ChatApp.Application.Service.Interfaces;
using ChatApp.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using ChatApp.Application.Features.User.Commands;
using FluentValidation;
using ChatApp.Application.Validators;

namespace ChatApp.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblies(typeof(RegisterUserCommandHandler).Assembly));

        services.AddValidatorsFromAssemblyContaining<RegisterUserDtoValidator>();
        services.AddTransient<IPasswordService, PasswordService>();

        return services;
    }
}
