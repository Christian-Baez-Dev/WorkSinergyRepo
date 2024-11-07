namespace WorkSynergy.Core.Domain.Models
{
    public class Message
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string MessageString { get; set; }
    }
}
