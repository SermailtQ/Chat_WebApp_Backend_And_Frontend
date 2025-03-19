namespace ChatApp.Domain.Models;

public class RoleClaimsEntity
{
    public required int UserId { get; set; }
    public required int RoleId { get; set; }

    public virtual required UserEntity User { get; set; }
    public virtual required RoleEntity Role { get; set; }

}
