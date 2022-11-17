using UDPTracker.Services.Filters;

namespace UDPTracker.Services.Interfaces
{
    public interface IIPService
    {
        Task CreateAsync(string ip);
    }
}