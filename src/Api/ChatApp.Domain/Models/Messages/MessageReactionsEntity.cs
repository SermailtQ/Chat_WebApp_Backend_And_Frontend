namespace ChatApp.Domain.Models.Messages
{
    public class MessageReactionsEntity : BaseEntity
    {
        public required int MessageId { get; set; }
        public required int SenderId { get; set; }
        public required string Reaction { get; set; }

        public virtual required MessageEntity Message { get; set; }

        public virtual required UserEntity Sender { get; set; }


    }
}
