namespace ChatApp.Infrastructure.Models;

public class UserEntity : BaseEntity
{
    public required string Username { get; set; }
    public required string Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Adress { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required DateTime Birthdate { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public DateTime LastLogin { get; set; } = DateTime.UtcNow;

    public virtual required List<RoleEntity> Roles { get; set; }
    public virtual List<MessageReactionsEntity>? MessageReactions { get; set; }
    public virtual List<ParticipantsEntity>? Participants { get; set; }
    public virtual List<MessageEntity>? Messages { get; set; }

}
