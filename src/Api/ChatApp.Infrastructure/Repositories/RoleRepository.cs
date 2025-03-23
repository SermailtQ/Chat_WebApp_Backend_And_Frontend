using ChatApp.Infrastructure.Context;
using ChatApp.Infrastructure.Models;
using ChatApp.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;

public class RoleRepository(ChatDbContext _context) : IRoleRepository
{
    private readonly string AdminRoleName = "Admin";
    private readonly string UserRoleName = "User";

    public async Task<RoleEntity> GetAdminRoleAsync()
    {
       return await _context.Roles.FirstOrDefaultAsync(n => n.Name.Equals(AdminRoleName)) ?? throw new NullReferenceException("Server error : " + AdminRoleName + " role nout found");

    }

    public async Task<RoleEntity> GetUserRoleAsync()
    {

        return await _context.Roles.FirstOrDefaultAsync(n => n.Name.Equals(UserRoleName)) ?? throw new NullReferenceException("Server error : " + UserRoleName + " role nout found");
    }
}
