using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class SimpleTcpClient
{
    public static async Task Main()
    {
        using var client = new TcpClient();
        await client.ConnectAsync("127.0.0.1", 9000);
        Console.WriteLine("Connected to server.");
        var bytes = Encoding.UTF8.GetBytes("Hello Server\n");
        await client.GetStream().WriteAsync(bytes, 0, bytes.Length);
        Console.WriteLine("Sent.");
    }
}