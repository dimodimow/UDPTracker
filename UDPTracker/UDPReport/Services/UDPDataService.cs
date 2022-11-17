using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using UDPReport.Models;
using UDPReport.Services.Interfaces;

namespace UDPReport.Services
{
    public class UDPDataService : IUDPDataService
    {
        public async Task<IEnumerable<UDPDataModel>> FindByAsync(UDPDataFilter filter)
        {
            var result = new List<UDPDataModel>();

            var query = new Dictionary<string, string>()
            {
                {"ip", filter.IP ?? string.Empty  },
                {"dateFrom", filter.DateFrom.ToString() ?? string.Empty },
                {"dateTo", filter.DateTo.ToString() ?? string.Empty },
            };

            using (var client = new HttpClient())
            {
                var requestUri = QueryHelpers.AddQueryString("https://localhost:7294/api/message/", query);
                var response = await client.GetAsync(requestUri);

                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<List<UDPDataModel>>(content) ?? new List<UDPDataModel>();

                result.AddRange(data);
            }

            return result;
        }
    }
}
