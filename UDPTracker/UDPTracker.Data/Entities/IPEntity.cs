using System.ComponentModel.DataAnnotations;

namespace UDPTracker.Data.Entities
{
    public class IPEntity : BaseEntity
    {
        public IPEntity()
        {
            this.Ip = string.Empty;
            this.Messages = new List<MessageEntity>();
        }

        [Required(AllowEmptyStrings = false)]
        public string Ip { get; set; }

        public ICollection<MessageEntity> Messages { get; set; }
    }
}