using System;
using System.IO;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        string dir = Path.Combine(Directory.GetCurrentDirectory(), "data");
        Directory.CreateDirectory(dir);

        string path = Path.Combine(dir, "note.txt");
        string content = "Hello File\n这是写入文件的内容。";

        File.WriteAllText(path, content, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        Console.WriteLine($"已写入: {path}");

        string readback = File.ReadAllText(path, Encoding.UTF8);
        Console.WriteLine("读入内容：");
        Console.WriteLine(readback);

        File.AppendAllText(path, "\n--这是一行追加的内容哦", Encoding.UTF8);
        Console.WriteLine("已追加一行，再次读取：");
        Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));


    }

}

