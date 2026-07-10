using System;

class Student
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
    }
}

class ClassDemo
{
    public void DisplayStudent()
    {
        Student s1 = new();

        s1.Name = "Omkar";
        s1.Age = 22;

        s1.Display();
    }
}
