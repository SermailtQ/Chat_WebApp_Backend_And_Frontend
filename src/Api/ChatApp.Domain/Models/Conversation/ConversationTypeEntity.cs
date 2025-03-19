namespace ChatApp.Domain.Models;

public class ConversationTypeEntity : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public virtual List<ConversationEntity>? Conversation { get; set; }

}
