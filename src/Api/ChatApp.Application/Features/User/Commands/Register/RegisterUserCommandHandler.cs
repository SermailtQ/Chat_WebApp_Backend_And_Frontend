﻿using ChatApp.Infrastructure.Models;
using ChatApp.Infrastructure.Repositories;
using ChatApp.Infrastructure.Repositories.Interfaces;
using ChatApp.Infrastructure.UnitOfWork;
using MediatR;

namespace ChatApp.Application.Features.User.Commands;

public class RegisterUserCommandHandler(IUserRepository _userRepository, IRoleRepository _roleRepository, IUnitOfWork _unitOfWork) 
    : IRequestHandler<RegisterUserCommand>
{
    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var entity = request.entity;

        if (await _userRepository.DoesEmailExist(entity.Email))
            throw new InvalidOperationException("The email adress: " + entity.Email + " is already used");

        var userRole = await _roleRepository.GetUserRoleAsync();

        var userToInsert = new UserEntity()
        {
            Username = entity.Email,
            Email = entity.Email,
            Birthdate = entity.BirthDate,
            Adress = entity.Adress,
            Firstname = entity.Firstname,
            Lastname = entity.Lastname,
            Password = entity.Password, // TODO: Add password encryption
            Roles = new List<RoleEntity>() { userRole }
        };

        try
        {
            await _userRepository.AddUserAsync(userToInsert);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
