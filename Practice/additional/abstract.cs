public abstract class Emp : IEmp
{
    public abstract void AddEmployee();
    public abstract void UpdateEmployee();
    public void DeleteEmployee()
    {
        Console.Write("Employee Deleted");
    }
}

public class Operations: Emp
{
    public override void AddEmployee()
    {
        Console.Write("Employee Added");
    }

    public override void UpdateEmployee()
    {
        Console.Write("Employee Updated");
    }
}