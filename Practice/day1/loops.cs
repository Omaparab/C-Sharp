using System;

public class LoopDemo
{
    public void displayLoops()
    {
        string name = "Omkar";

        Console.WriteLine("For Loop:");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{i}. {name}");
        }

        Console.WriteLine("\nWhile Loop:");
        int count = 1;
        while (count <= 3)
        {
            Console.WriteLine($"Count = {count}");
            count++;
        }

        Console.WriteLine("\nDo-While Loop:");
        int num = 1;
        do
        {
            Console.WriteLine($"Number = {num}");
            num++;
        }
        while (num <= 3);

    }
}