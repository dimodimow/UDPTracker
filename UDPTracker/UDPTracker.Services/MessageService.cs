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
            var ip = await this.context.IPs.FirstOrDefaultAsync(x => x.Ip == model.IP);

            if (ip == null || ip.Id == Guid.Empty)
            {
                return;
            }

            this.context.Messages.Add(new MessageEntity
            {
                Message = model.Message,
                IPId = ip.Id,
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
            DateTimeOffset? dateTo = string.IsNullOrEmpty(filter.DateTo) ? null : DateTimeOffset.Parse(filter.DateTo);
            DateTimeOffset? dateFrom = string.IsNullOrEmpty(filter.DateFrom) ? null : DateTimeOffset.Parse(filter.DateFrom);

            return x => (string.IsNullOrEmpty(filter.IP) || x.IP.Ip.Contains(filter.IP)) &&
                     (dateTo == null || x.CreatedAt <= dateTo) &&
                    (dateFrom == null || x.CreatedAt >= dateFrom);
        }
    }
}