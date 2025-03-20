namespace ChatApp.Domain.Models;

public class FileTypeEntity : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public virtual required List<MessageAttachementEntity> Attachements { get; set; }
}
