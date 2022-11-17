using Microsoft.EntityFrameworkCore;
using UDPTracker.Data.Context;
using UDPTracker.Services;
using UDPTracker.Services.Interfaces;

namespace UDPTracker.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IIPService, IPService>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IUDPServerService, UDPServerService>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<UDPTrackerDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return builder;
        }
    }
}
