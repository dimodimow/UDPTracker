using System.Net.Sockets;
using System.Net;
using System.Text;


Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

//Getting local IP
var ipAddress = Dns.GetHostAddresses(Dns.GetHostName())[1];

var message = Console.ReadLine();

while (true)
{
    byte[] buffer = Encoding.ASCII.GetBytes(message);
    var ep = new IPEndPoint(ipAddress, 11000);

    s.SendTo(buffer, ep);

    Console.WriteLine("Message sent to the broadcast address");

    message = Console.ReadLine();
}