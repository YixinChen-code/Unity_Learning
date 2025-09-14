using System;
using System.Threading;

class Program
{
    static async Task HelloLoop()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Hello");
            await Task.Delay(1000);
        }
    }

    static async Task Main()
    {
        await HelloLoop();
        Console.WriteLine("Done.");
    }

}

