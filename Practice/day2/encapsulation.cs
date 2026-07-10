using System;

class Employee
{
    private double salary;

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Name { get; set; } = string.Empty;
}

class EncapsulationDemo
{
    public void show()
    {
        Employee emp = new();

        emp.Name = "Omkar";
        emp.Salary = 50000;

        Console.WriteLine("Name: " + emp.Name);
        Console.WriteLine("Salary: " + emp.Salary);
    }
}