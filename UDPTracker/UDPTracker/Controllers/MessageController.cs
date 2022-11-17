using Microsoft.AspNetCore.Mvc;
using UDPTracker.Services.Filters;
using UDPTracker.Services.Interfaces;
using UDPTracker.Services.Models;

namespace UDPTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;
        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IEnumerable<MessageModel>> Get([FromQuery] MessageFilter filter)
        => await this.messageService.FindBy(filter);
    }
}