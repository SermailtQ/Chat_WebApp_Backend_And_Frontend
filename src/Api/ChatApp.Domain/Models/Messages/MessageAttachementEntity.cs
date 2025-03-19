using ChatApp.Domain.Models.Messages;

namespace ChatApp.Domain.Models
{
    public class MessageAttachementEntity : BaseEntity
    {
        public required int MessageId { get; set; }
        public required string FileUrl { get; set; }
        public required string FileTypeId { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public virtual required MessageEntity Message { get; set; }
        public virtual required FileTypeEntity FileType { get; set; }
    }
}
