using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Text;
using UDPTracker.Data.Context;
using UDPTracker.Services.Interfaces;
using UDPTracker.Services.Models;

namespace UDPTracker.Services
{
    public class UDPServerService : IUDPServerService
    {
        private readonly UDPTrackerDbContext context;
        private readonly IIPService iPService;
        private readonly IMessageService messageService;

        public UDPServerService(UDPTrackerDbContext context,
            IIPService iPService,
            IMessageService messageService)
        {
            this.context = context;
            this.iPService = iPService;
            this.messageService = messageService;
        }

        public void StartListener()
        {
            Task.Run(async () =>
              {
                  var udpClient = new UdpClient(11000);

                  while (true)
                  {
                      var result = await udpClient.ReceiveAsync();

                      await this.SaveData(result);
                  }
              });
        }

        private async Task SaveData(UdpReceiveResult result)
        {
            var ip = result.RemoteEndPoint.Address.ToString();

            var message = Encoding.UTF8.GetString(result.Buffer);

            var isIpExisting = await this.context.IPs.FirstOrDefaultAsync(x => x.Ip == ip);

            if (isIpExisting == null)
            {
                await this.iPService.CreateAsync(ip);
            }

            await this.messageService.CreateAsync(new CreateMessageModel
            {
                IP = ip,
                Message = message
            });
        }
    }
}