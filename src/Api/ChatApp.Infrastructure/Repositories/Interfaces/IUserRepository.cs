using ChatApp.Infrastructure.Models;

namespace ChatApp.Infrastructure.Repositories;
public interface IUserRepository
{
    Task<UserEntity> GetByEmailAsync(string email);
    Task<bool> DoesEmailExist(string email);
    Task AddUserAsync(UserEntity entity);
    Task UpdateUserAsync(UserEntity entity);
    Task DeactivateUserAsync(string email);
}
