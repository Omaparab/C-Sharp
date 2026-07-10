using System;
using System.IO;

class FileDemo
{
    public void showFile()
    {
        string path = "demo.txt";

        File.WriteAllText(path, "Hello from C# file handling");

        string content = File.ReadAllText(path);
        Console.WriteLine("File content: " + content);

        File.AppendAllText(path, "\nAdded more text");

        string updatedContent = File.ReadAllText(path);
        Console.WriteLine("Updated content: " + updatedContent);

        // File.Delete(path);
    }
}
