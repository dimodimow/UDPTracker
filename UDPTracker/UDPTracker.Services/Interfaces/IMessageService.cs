using UDPTracker.Services.Filters;
using UDPTracker.Services.Models;

namespace UDPTracker.Services.Interfaces
{
    public interface IMessageService
    {
        Task CreateAsync(CreateMessageModel model);
        Task<IEnumerable<MessageModel>> FindBy(MessageFilter filter);
    }
}