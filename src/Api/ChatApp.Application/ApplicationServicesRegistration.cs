using ChatApp.Application.Service.Interfaces;
using ChatApp.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using ChatApp.Application.Features.User.Commands;
using FluentValidation;
using ChatApp.Application.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ChatApp.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblies(typeof(RegisterUserCommandHandler).Assembly));

        var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        services.AddAuthorization();

        services.AddValidatorsFromAssemblyContaining<RegisterUserDtoValidator>();
        services.AddTransient<IPasswordService, PasswordService>();
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }
}
