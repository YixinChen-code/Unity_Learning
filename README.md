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





