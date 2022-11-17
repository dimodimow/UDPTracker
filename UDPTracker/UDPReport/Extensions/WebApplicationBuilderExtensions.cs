using UDPReport.Services;
using UDPReport.Services.Interfaces;

namespace UDPReport.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUDPDataService, UDPDataService>();

            return builder;
        }
    }
}
