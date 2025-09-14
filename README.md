# Unity_Learning

第 1 步：用命令创建控制台项目
打开 VS Code 顶部菜单 Terminal → New Terminal（新建终端）。
在终端里依次输入以下命令（每行回车执行）：
```c#
mkdir CSharpPractice
cd CSharpPractice
dotnet new console -n Basics
code .
```
第一次执行完后，VS Code 会打开 Basics 这个项目文件夹。
如果提示 “是否信任该文件夹”，点 Trust。

  
第 2 步：运行默认模板（确认环境OK）
在 VS Code 资源管理器里打开 Program.cs。
直接在终端运行：
```c#
cd Basics
dotnet run
```
你应该会看到输出：Hello, World!
  
第 3 步：完成任务 1（Hello, C#）
把 Program.cs 内容替换为下面这段，保存（Ctrl+S）：
```
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, C#");
    }
}
```
再次运行：
```
dotnet run
```
应输出：Hello, C#
  
第 4 步：做任务 2（变量与插值）

继续编辑同一个 Program.cs，替换为：
```
using System;

class Program
{
    static void Main(string[] args)
    {
        int age = 20;
        double score = 92.5;
        bool isStudent = true;
        string name = "Jerry";

        Console.WriteLine($"Name: {name}, Age: {age}, Score: {score}, IsStudent: {isStudent}");
    }
}
```
运行 dotnet run，观察输出是否包含四个变量值。
  
第 5 步：做任务 3（九九乘法表）
把 Program.cs 改为：
```
using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                Console.Write($"{i}x{j}={(i*j),2}  ");
            }
            Console.WriteLine();
        }
    }
}
```
运行 dotnet run，检查输出是否对齐整齐。
   
##（选做）VS Code 里更方便的运行方式
左侧 Run and Debug（运行与调试） ▶️ → 选择 .NET → Run。
或者在 Program.cs 顶部出现的 Run/Debug 按钮直接点击。
  
任务 4：条件 & switch（成绩等级）
```
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("请输入成绩(0~100): ");
        string? line = Console.ReadLine();

        if (!int.TryParse(line, out int score) || score < 0 || score > 100)
        {
            Console.WriteLine("输入无效");
            return;
        }

        // if-else 版本
        string level;
        if (score >= 90) level = "优秀";
        else if (score >= 80) level = "良好";
        else if (score >= 60) level = "及格";
        else level = "不及格";
        Console.WriteLine($"if-else 判定：{level}");

        // switch 表达式版本（C# 8+）
        string level2 = score switch
        {
            >= 90 => "优秀",
            >= 80 => "良好",
            >= 60 => "及格",
            _ => "不及格"
        };
        Console.WriteLine($"switch 判定：{level2}");
    }
}
```

任务 6：方法与类
```
using System;

class Person
{
    public string Name = "";
    public int Age;

    public void Introduce()
    {
        Console.WriteLine($"Hi, I am {Name}, {Age} years old.");
    }
}

class Program
{
    // 有返回值的方法
    static int Add(int a, int b) => a + b;

    // 无返回值的方法
    static void SayHello(string name) => Console.WriteLine($"Hello, {name}");

    static void Main(string[] args)
    {
        Console.WriteLine($"3 + 5 = {Add(3, 5)}");
        SayHello("Jerry");

        var p = new Person { Name = "Alice", Age = 22 };
        p.Introduce();
    }
}
```
任务 7：文件读写（File I/O）
```
using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // 建议写到项目目录下的 data 子文件夹
        string dir = Path.Combine(Directory.GetCurrentDirectory(), "data");
        Directory.CreateDirectory(dir);

        string path = Path.Combine(dir, "note.txt");
        string content = "Hello File\n这是写入文件的内容。";

        // 写入（UTF-8）
        File.WriteAllText(path, content, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        Console.WriteLine($"已写入：{path}");

        // 读取
        string readBack = File.ReadAllText(path, Encoding.UTF8);
        Console.WriteLine("读取内容：");
        Console.WriteLine(readBack);

        // 追加写入
        File.AppendAllText(path, "\n—— 这是一行追加内容", Encoding.UTF8);
        Console.WriteLine("已追加一行，再次读取：");
        Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));
    }
}
```

运行后，在项目目录会生成 data/note.txt。

任务 8：字符串清理（正则与空白去除）
```
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string raw = "  A  B \n C\t ";
        // 去掉所有空白字符（空格、换行、制表符等）
        string cleaned = Regex.Replace(raw, @"\s+", "");

        Console.WriteLine($"原始: [{raw}]");
        Console.WriteLine($"清理: [{cleaned}]"); // 期望输出: [ABC]

        // 如果只想去掉两端空白（保留中间空格），用 Trim():
        string onlyTrim = raw.Trim();
        Console.WriteLine($"仅去两端空白: [{onlyTrim}]");
    }
}
```
