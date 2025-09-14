using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task<int> Sum1To100()
    {
        return await Task.Run(() => Enumerable.Range(1, 100).Sum());
    }

    static async Task Countdown()
    {
        for (int i = 100; i >= 1; i--)
        {
            Console.Write($"{i} ");
            await Task.Delay(10);
        }
        Console.WriteLine();
    }

    static async Task Main()
    {
        Task<int> sumTask = Sum1To100();
        Task countdownTask = Countdown();

        await Task.WhenAll(sumTask, countdownTask);
        Console.WriteLine($"Sum(1..100)={sumTask.Result}");
        
    }



}

