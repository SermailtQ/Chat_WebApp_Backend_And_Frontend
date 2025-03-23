namespace ChatApp.Infrastructure.Models;
public class RoleEntity : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public virtual required List<UserEntity> Users { get; set; }
}
