namespace ChatApp.Infrastructure.Models;
public class ConversationRoleEntity : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public  virtual required List<ParticipantsEntity> Participants { get; set; }
}
