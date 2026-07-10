using EmployeeManagement.Services;

namespace EmployeeManagement
{
    class Program
    {
        static void Main()
        {
            DataverseService ds = new DataverseService();

            var client = ds.Connect();

            Console.WriteLine($"Connection Status: {client.IsReady}");

            if (!client.IsReady)
            {
                Console.WriteLine(client.LastError);
                Console.ReadKey();
                return;
            }

            Employee_Service service = new Employee_Service();

            while (true)
            {
                Console.WriteLine("\nPerform your operation:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Show Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");

                Console.Write("Enter Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        service.AddEmployee();
                        break;

                    case 2:
                        service.ShowEmployees();
                        break;

                    case 3:
                        service.UpdateEmployee();
                        break;

                    case 4:
                        service.DeleteEmployee();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
    }
}