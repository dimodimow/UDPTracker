using Microsoft.EntityFrameworkCore;
using UDPTracker.Data.Entities;

namespace UDPTracker.Data.Context
{
    public class UDPTrackerDbContext : DbContext
    {
        public UDPTrackerDbContext(DbContextOptions<UDPTrackerDbContext> options) : base(options)
        {}

        public DbSet<IPEntity> IPs { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}