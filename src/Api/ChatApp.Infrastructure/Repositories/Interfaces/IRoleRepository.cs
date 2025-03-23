using ChatApp.Infrastructure.Models;

namespace ChatApp.Infrastructure.Repositories.Interfaces
{
    public interface IRoleRepository
    {
         Task<RoleEntity> GetAdminRoleAsync();
         Task<RoleEntity> GetUserRoleAsync();
    }
}
