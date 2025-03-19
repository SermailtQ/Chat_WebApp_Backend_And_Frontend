namespace ChatApp.Domain.Models.Messages;

public class MessageEntity : BaseEntity
{
    public required int ConversationId { get; set; }
    public required int SenderId { get; set; }
    public required string Message { get; set; }
    public required string Status { get; set; } // TODO: Rethink
    public DateTime SendAt { get; set; } = DateTime.UtcNow;
    public int? ReplyId { get; set; }

    public virtual required ConversationEntity Conversation { get; set; }
    public virtual required UserEntity Sender { get; set; }
    public virtual required MessageEntity Reply { get; set; }
    public virtual required List<MessageReactionsEntity> MessageReactions { get; set; }
    public virtual required List<MessageEntity> Replys { get; set; }
    public virtual required List<MessageAttachementEntity> Attachements { get; set; }
}
