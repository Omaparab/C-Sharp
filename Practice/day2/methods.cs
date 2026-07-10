using System;

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

   
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    
    public void Greet(string name = "Guest")
    {
        Console.WriteLine("Hello " + name);
    }
}

class Program3
{
    public void CalcDemo()
    {
        Calculator calc = new Calculator();

        Console.WriteLine("Sum of 2 numbers: " + calc.Add(10, 20));
        Console.WriteLine("Sum of 3 numbers: " + calc.Add(10, 20, 30));

        calc.Greet();
        calc.Greet("Omkar");
    }
}