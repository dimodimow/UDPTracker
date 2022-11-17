using UDPTracker.Data.Context;
using UDPTracker.Data.Entities;
using UDPTracker.Services.Interfaces;

namespace UDPTracker.Services
{
    public class IPService : IIPService
    {
        private readonly UDPTrackerDbContext context;
        public IPService(UDPTrackerDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(string ip)
        {
            await this.context.IPs.AddAsync(new IPEntity
            {
                Ip = ip,
                CreatedAt = DateTime.Now
            });

            await this.context.SaveChangesAsync();
        }
    }
}
