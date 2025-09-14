// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

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
    static int Add(int a, int b) => a + b;
    static void SayHello(string name) => Console.WriteLine($"Hello, {name}");

    static void Main(string[] args)
    {
        Console.WriteLine($"3+5={Add(3, 5)}");
        SayHello("Jerry");

        var p = new Person { Name = "Alice", Age = 22 };
        p.Introduce();
    }

}

