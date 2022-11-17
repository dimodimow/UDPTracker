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
        private readonly IIPService ipService;
        private readonly IMessageService messageService;

        public UDPServerService(UDPTrackerDbContext context,
            IIPService ipService,
            IMessageService messageService)
        {
            this.context = context;
            this.ipService = ipService;
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

            var ipEntity = await this.context.IPs.FirstOrDefaultAsync(x => x.Ip == ip);

            if (ipEntity == null)
            {
                await this.ipService.CreateAsync(ip);
            }

            await this.messageService.CreateAsync(new CreateMessageModel
            {
                IP = ip,
                Message = message
            });
        }
    }
}