using System.ComponentModel.DataAnnotations;
using UDPTracker.Data.Entities.Interfaces;

namespace UDPTracker.Data.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
