# Unity_Learning

第 1 步：用命令创建控制台项目
打开 VS Code 顶部菜单 Terminal → New Terminal（新建终端）。
在终端里依次输入以下命令（每行回车执行）：
mkdir CSharpPractice
cd CSharpPractice
dotnet new console -n Basics
code .
第一次执行完后，VS Code 会打开 Basics 这个项目文件夹。
如果提示 “是否信任该文件夹”，点 Trust。

  
第 2 步：运行默认模板（确认环境OK）
在 VS Code 资源管理器里打开 Program.cs。
直接在终端运行：
```c#
cd Basics
dotnet run

你应该会看到输出：Hello, World!

  
第 3 步：完成任务 1（Hello, C#）
把 Program.cs 内容替换为下面这段，保存（Ctrl+S）：
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, C#");
    }
}
再次运行：
dotnet run
应输出：Hello, C#









