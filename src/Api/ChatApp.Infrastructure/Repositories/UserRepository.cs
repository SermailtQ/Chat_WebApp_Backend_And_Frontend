using ChatApp.Infrastructure.Context;
using ChatApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly ChatDbContext _context;

    public UserRepository(ChatDbContext context) => _context = context;

    public async Task AddUserAsync(UserEntity entity)
    {
        await _context.Users.AddAsync(entity);
    }

    public Task DeactivateUserAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DoesEmailExist(string email)
    {
       return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<UserEntity> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email)
                     ?? throw new InvalidOperationException($"User with email {email} not found.");
    }

    public async Task UpdateLastLoginAsync(Guid Id)
    {
        var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);

        if (entity == null)
            throw new InvalidOperationException("User not found");

        entity.LastLogin = entity.LastLogin;
        
        _context.Entry(entity).Property(u => u.LastLogin).IsModified = true;
    }
}
