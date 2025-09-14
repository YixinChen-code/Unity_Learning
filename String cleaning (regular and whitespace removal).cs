using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string raw = "A B \n C\t ";
        string cleaned = Regex.Replace(raw, @"\s+", "");

        Console.WriteLine($"原始:[{raw}]");
        Console.WriteLine($"清理:[{cleaned}]");

        string onlyTrim = raw.Trim();
        Console.WriteLine($"仅去两端空白: [{onlyTrim}]");
    }

}

