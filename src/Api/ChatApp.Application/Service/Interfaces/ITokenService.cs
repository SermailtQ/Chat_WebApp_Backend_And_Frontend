using ChatApp.Infrastructure.Models;

namespace ChatApp.Application.Service.Interfaces;
public interface ITokenService
{
    string CreateToken(UserEntity entity);
}
