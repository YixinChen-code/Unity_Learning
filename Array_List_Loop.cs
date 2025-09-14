// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        Console.WriteLine($"数组和= {sum}");
        List<string> fruits = new List<string> { "apple", "banana" };
        fruits.Add("orange");
        fruits.Remove("banana");
        bool hasApple = fruits.Contains("apple");

        Console.WriteLine("fruits 列表: ");
        foreach (var f in fruits)
            Console.Write($"-{f}");
        Console.WriteLine($"是否包含apple?{hasApple}");
        
    }

}

