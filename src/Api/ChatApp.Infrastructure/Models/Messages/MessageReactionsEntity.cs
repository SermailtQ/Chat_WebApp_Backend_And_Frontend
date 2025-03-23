namespace ChatApp.Infrastructure.Models;
public class MessageReactionsEntity : BaseEntity
{
    public required Guid MessageId { get; set; }
    public required Guid SenderId { get; set; }
    public required string Reaction { get; set; }

    public virtual required MessageEntity Message { get; set; }

    public virtual required UserEntity Sender { get; set; }


}
