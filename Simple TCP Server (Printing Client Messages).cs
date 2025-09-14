using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class SimpleTcpServer
{
    public static async Task Main()
    {
        var listener = new TcpListener(IPAddress.Loopback, 9000);
        listener.Start();
        Console.WriteLine("server listening on 127.0.0.1:9000");

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            _ = HandleClient(client);
        }
    }


    static async Task HandleClient(TcpClient client)
    {
        Console.WriteLine("client connected.");
        using var stream = client.GetStream();

        var buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
        Console.WriteLine($"received:{msg}");
        client.Close();
    }
}

