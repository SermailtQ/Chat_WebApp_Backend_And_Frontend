using ChatApp.Application.Features.User.Commands;
using ChatApp.Infrastructure.Context;
using ChatApp.Infrastructure.Repositories.Interfaces;
using ChatApp.Infrastructure.Repositories;
using ChatApp.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using ChatApp.Application.Service.Interfaces;
using ChatApp.Application.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChatDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MainDbConnection")));

builder.Services.AddMediatR(configuration => {
    configuration.RegisterServicesFromAssemblies(typeof(RegisterUserCommandHandler).Assembly);
    });

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IPasswordService, PasswordService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
