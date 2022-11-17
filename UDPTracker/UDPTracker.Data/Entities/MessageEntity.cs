using System.ComponentModel.DataAnnotations.Schema;

namespace UDPTracker.Data.Entities
{
    public class MessageEntity : BaseEntity
    {
        public string? Message { get; set; }

        public Guid IPId { get; set; }

        [ForeignKey(nameof(IPId))]
        public IPEntity IP { get; set; }
    }
}