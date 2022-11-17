using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UDPTracker.Data.Context;
using UDPTracker.Data.Entities;
using UDPTracker.Services.Filters;
using UDPTracker.Services.Interfaces;
using UDPTracker.Services.Models;

namespace UDPTracker.Services
{
    public class MessageService : IMessageService
    {
        private readonly UDPTrackerDbContext context;
        public MessageService(UDPTrackerDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(CreateMessageModel model)
        {
            var ipId = await this.context.IPs.FirstOrDefaultAsync(x => x.Ip == model.IP);

            if (ipId == null || ipId.Id == Guid.Empty)
            {
                return;
            }

            this.context.Messages.Add(new MessageEntity
            {
                Message = model.Message,
                IPId = ipId.Id,
                CreatedAt = DateTime.Now
            });

            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MessageModel>> FindBy(MessageFilter filter)
        {
            var filtered = this.Filter(filter);

            var messages = await this.context.Messages.Where(filtered).ToListAsync();

            return messages.Select(x => new MessageModel
            {
                Message = x.Message,
                CreatedAt = x.CreatedAt
            });
        }

        private Expression<Func<MessageEntity, bool>> Filter(MessageFilter filter)
        {
            return x => (string.IsNullOrEmpty(filter.IP) || x.IP.Ip.Contains(filter.IP)) &&
                     (!filter.DateTo.HasValue || x.CreatedAt <= filter.DateTo) &&
                    (!filter.DateFrom.HasValue || x.CreatedAt >= filter.DateFrom);
        }
    }
}