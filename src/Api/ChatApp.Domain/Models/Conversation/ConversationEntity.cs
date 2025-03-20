namespace ChatApp.Domain.Models;

public class ConversationEntity : BaseEntity
{
    public required string Name { get; set; }
    public required Guid Conversati﻿onTypeId { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? Settings { get; set; } // Json

    public virtual required ConversationTypeEntity Type { get; set; }
    public virtual required List<MessageEntity> Messages { get; set; }
    public virtual required List<ParticipantsEntity> Participants { get; set; }
}
