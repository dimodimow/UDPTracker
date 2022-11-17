using System.ComponentModel.DataAnnotations;

namespace UDPTracker.Services.Models
{
    public class CreateMessageModel
    {
        [Required]
        public string? IP { get; set; }
        [Required]
        public string Message { get; set; }
    }
}