// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("请输入成绩(0~100):");
        string? line = Console.ReadLine();  //string?   可空字符串（nullable string）
        if (!int.TryParse(line, out int score) || score < 0 || score > 100)
        {
            Console.WriteLine("输入无效");
            return;
        }

        string level;
        if (score >= 90)
            level = "优秀";
        else if (score >= 80) level = "良好";
        else if (score >= 60) level = "及格";
        else level = "不及格";
        Console.WriteLine($"if-else判定：{level}");


        string level2 = score switch
        {
            >= 90 => "优秀",
            >= 80 => "良好",
            >= 60 => "及格",
            _ => "不及格"
        };
        Console.WriteLine($"switch 判定:{level2}");
        

    }

}

