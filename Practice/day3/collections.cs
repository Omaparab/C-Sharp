using System;
using System.Collections.Generic;

class CollectionsDemo
{
    public void showCollections()
    {
        List<string> fruits = new() { "Apple", "Banana", "Mango" };
        fruits.Add("Orange");

        Console.WriteLine("Fruits:");
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        Dictionary<string, int> marks = new()
        {
            { "Omkar", 90 },
            { "Riya", 85 }
        };

        Console.WriteLine("Marks:");
        foreach (var item in marks)
        {
            Console.WriteLine(item.Key + " = " + item.Value);
        }
    }
}
