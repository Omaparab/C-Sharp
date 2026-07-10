using System;

class Person
{
    protected string Name;

    public Person(string name)
    {
        Name = name;
        Console.WriteLine("Parent Constructor Called");
    }
}

class StudentWithConstructor : Person
{
    private int Age;

    public StudentWithConstructor(string name, int age) : base(name)
    {
        Age = age;
        Console.WriteLine("Child Constructor Called");
    }

    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
    }
}

class ConstructorDemo
{
    public void DisplayStudent()
    {
        StudentWithConstructor s = new("Omkar", 22);

        s.Display();
    }
}