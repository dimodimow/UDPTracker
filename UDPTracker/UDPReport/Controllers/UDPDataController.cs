using Microsoft.AspNetCore.Mvc;
using UDPReport.Models;
using UDPReport.Services.Interfaces;

namespace UDPReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UDPDataController : ControllerBase
    {
        private readonly IUDPDataService udpDataService;
        public UDPDataController(IUDPDataService udpDataService)
        {
            this.udpDataService = udpDataService;
        }

        [HttpGet]
        public async Task<IEnumerable<UDPDataModel>> Get([FromQuery] UDPDataFilter filter)
            => await this.udpDataService.FindByAsync(filter);
    }
}