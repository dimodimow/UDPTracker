using UDPReport.Models;

namespace UDPReport.Services.Interfaces
{
    public interface IUDPDataService
    {
        Task<IEnumerable<UDPDataModel>> FindByAsync(UDPDataFilter filter);
    }
}