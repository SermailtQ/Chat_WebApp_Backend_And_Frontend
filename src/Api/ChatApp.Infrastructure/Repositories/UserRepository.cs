using ChatApp.Infrastructure.Context;
using ChatApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly ChatDbContext _context;

    public UserRepository(ChatDbContext context) => _context = context;

    public Task AddUserAsync(UserEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeactivateUserAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<UserEntity> GetByEmailAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email)
                     ?? throw new InvalidOperationException($"User with email {email} not found.");
    }

    public Task UpdateUserAsync(UserEntity entity)
    {
        throw new NotImplementedException();
    }
}
