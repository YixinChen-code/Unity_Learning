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
## 下一阶段从4开始，算是任务9往后依次：
4.1 每秒打印一次“Hello”，持续 5 秒
```
using System;
using System.Threading.Tasks;

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
```
4.2 并行执行两个任务（求和 & 倒计时）
```
using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task<int> Sum1To100()
    {
        // 模拟计算任务
        return await Task.Run(() => Enumerable.Range(1, 100).Sum());
    }

    static async Task Countdown()
    {
        for (int i = 100; i >= 1; i--)
        {
            Console.Write($"{i} ");
            await Task.Delay(10); // 调小延迟，演示更快
        }
        Console.WriteLine();
    }

    static async Task Main()
    {
        Task<int> sumTask = Sum1To100();
        Task countdownTask = Countdown();

        await Task.WhenAll(sumTask, countdownTask);
        Console.WriteLine($"Sum(1..100) = {sumTask.Result}");
    }
}
```
阶段 5：网络编程基础（C# 控制台）

端口可改：9000。先运行服务器，再运行客户端。记得这里是两个项目哦，在一个电脑上，创建两个项目去运行。
<img width="2526" height="1503" alt="84843e54-7696-49f5-98aa-e3a517c7fc27" src="https://github.com/user-attachments/assets/706a6439-92a4-412f-83cb-5a0b337c893e" />

<img width="2529" height="1341" alt="f714ab24-042b-4de5-b909-66f7d841d8e8" src="https://github.com/user-attachments/assets/37c97bed-3aa4-45df-8494-a5cb8ada15a9" />

5.1 简易 TCP 服务器（打印客户端消息）
```
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
        Console.WriteLine("Server listening on 127.0.0.1:9000");

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            _ = HandleClient(client); // 丢到后台处理
        }
    }

    static async Task HandleClient(TcpClient client)
    {
        Console.WriteLine("Client connected.");
        using var stream = client.GetStream();
        var buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
        Console.WriteLine($"Received: {msg}");
        client.Close();
    }
}
```
5.2 简易 TCP 客户端（发送 “Hello Server”）
```
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
```
阶段六：用“完全零基础”的方式，在 Unity 里把这 3 个脚本跑起来。  
  
0）安装与创建工程：
安装 Unity Hub → 在 Hub 里安装一个 LTS 版本（比如 2022/2023 LTS）。
Hub 里点 New Project → 模板选 2D（Core/URP 都行） → 取名 UnityUIPractice → Create。
  
1）认识场景与层级
打开后，左侧 Hierarchy 是场景中的物体列表，中央是 Scene 视图。
UI 元素（Button/Image）会自动创建一个 Canvas（画布）和 EventSystem（负责点击事件）。
  
2）创建 UI：
在 Hierarchy 空白处右键 → UI → Button。
Unity 会自动创建：Canvas、EventSystem、Button。
右键 Canvas → UI → Image，得到一个 Image 方块。
选中 Image，在右侧 Inspector 面板里：
Rect Transform 调一下位置/大小（随意）。
Image（组件） 里把 Color 改为 黑色（让闪烁更明显）。
小提示：选 Canvas，查看 Canvas Scaler，把 UI Scale Mode 设成 Scale With Screen Size，分辨率随窗口变化更舒服。
  
3）创建脚本（C#）
在 Project 面板（下方）右键 → Create → C# Script，命名：
PrintOnClick  
BlinkImage  
ToggleImageColor  
双击脚本在编辑器里打开，把你发的代码分别完整替换进去，保存（Ctrl+S）。
  
4）把脚本挂到物体上（Add Component）
我们做一个最小场景：一个 Image + 两个 Button。
BlinkImage（控制闪烁） 
在 Hierarchy 里右键 → Create Empty，改名 UIController。    
选中 UIController → Inspector → Add Component → 搜索 BlinkImage 添加。  
在 BlinkImage 组件里，把 Target 字段拖拽为你创建的 Image。
频率 frequency、时长 duration 保持默认即可。
ToggleImageColor（红/黑切换）
仍在 UIController 上 Add Component → 搜索 ToggleImageColor 添加。
把 Target 字段也拖 Image 过去。
PrintOnClick（按钮打印）
选择 Button，Add Component → 搜索 PrintOnClick 添加到 Button 上。
  
5）连按钮事件（OnClick）
选中第一个 Button，Inspector → Button（Script） → On Click() 区域：
点 “+” 新增一行。
把 UIController 拖到那一行的空物体槽里。
右侧函数下拉框选：BlinkImage → StartBlink() 。
这个按钮就成了“开始闪烁”按钮。
复制这个 Button（Ctrl+D），拖到旁边作为第二个按钮：
On Click() 里把对象仍然设为 UIController。
右侧函数选择：ToggleImageColor → ToggleColor()。
这个按钮就是“红/黑切换”按钮。
想测试打印功能的话，在任意一个 Button 的 OnClick() 再加一行：
这次把对象设为Button 自己（或把 UIController 上添加 PrintOnClick 也行）。
选择 PrintOnClick → OnButtonClicked()。
OnClick 可以加多行回调；一个按钮既能触发闪烁，又能打印日志。
  
6）运行
顶部点击 Play ▶。
点“开始闪烁”按钮：Image 在黑白之间正弦闪烁，持续 duration 秒后回到黑色。
点“红/黑切换”按钮：Image 在红色和黑色之间切换。
看 Console 面板（Window → General → Console），能看到 "Button Clicked" 日志。

```BlinkImage
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkImage : MonoBehaviour
{
    public Image target;
    public float frequency = 10f; // Hz
    public float duration = 10f;

    public void StartBlink()
    {
        StopAllCoroutines();
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        if (target == null) yield break;

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float v = 0.5f * (1 + Mathf.Sin(2 * Mathf.PI * frequency * t)); // <- Mathf
            target.color = Color.Lerp(Color.black, Color.white, v);
            yield return null;
        }
        target.color = Color.black;
    }
}
```
+++
```PrintOnClick
using UnityEngine;

public class PrintOnClick : MonoBehaviour
{
    public void OnButtonClicked()
    {
        Debug.Log("Button Clicked");
    }
}
```
+++
```ToggleImageColor
using UnityEngine;
using UnityEngine.UI;

public class ToggleImageColor : MonoBehaviour
{
    public Image target;
    private bool isRed = false;

    public void ToggleColor()
    {
        if (target == null) return;
        isRed = !isRed;
        target.color = isRed ? Color.red : Color.black;
    }
}
```
