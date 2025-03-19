namespace ChatApp.Domain.Models;

public class ParticipantsEntity : BaseEntity
{
    public required int ConversationId { get; set; }
    public required int UserId { get; set; }
    public int ConversationRoleId { get; set; }

    public required DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public virtual required ConversationRoleEntity ConversationRole { get; set; }
    public virtual required ConversationEntity Conversation { get; set; }
    public virtual required UserEntity User { get; set; }
}
