using ChatApp.Application.Service.Interfaces;
using ChatApp.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ChatApp.Application.Service;
public sealed class TokenService(IConfiguration _configuration) : ITokenService
{
    public string CreateToken(UserEntity entity)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            GetClaims(entity),
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private List<Claim> GetClaims(UserEntity entity)
    {
        return new List<Claim>
        {
            new (JwtRegisteredClaimNames.Sub, entity.Id.ToString()),
            new (JwtRegisteredClaimNames.Email, entity.Email),
        };
    }

}
