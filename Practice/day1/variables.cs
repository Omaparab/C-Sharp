using System;

public class VarDemo
{
    public void displayVariables()
    {
        byte marks = 95;
        short year = 2025;
        int age = 22;
        long population = 1400000000;

        float height = 5.9f;
        double salary = 25000.50;
        decimal accountBalance = 10000.75m;

        char grade = 'A';
        bool isTrainee = true;
        string name = "Omkar";

        var city = "Mumbai";

        Console.WriteLine($"Marks: {marks}");
        Console.WriteLine($"Year: {year}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Population: {population}");
        Console.WriteLine($"Height: {height}");
        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine($"Account Balance: {accountBalance}");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine($"Is Trainee: {isTrainee}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"City: {city}");
    }
}