namespace ChatApp.Infrastructure.Models;
public class ParticipantsEntity
{
    public required Guid ConversationId { get; set; }
    public required Guid UserId { get; set; }
    public required Guid ConversationRoleId { get; set; }

    public required DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public virtual required ConversationRoleEntity ConversationRole { get; set; }
    public virtual required ConversationEntity Conversation { get; set; }
    public virtual required UserEntity User { get; set; }
}
