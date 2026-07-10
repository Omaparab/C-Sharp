using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class Employee_Service
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Employee Code: ");
            emp.EmployeeCode = Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            emp.Email = Console.ReadLine() ?? string.Empty;

            Console.Write("Department: ");
            emp.Department = Console.ReadLine() ?? string.Empty;

            Console.Write("Experience Years: ");
            emp.ExperienceYears =
                Convert.ToDouble(Console.ReadLine() ?? "0");

            employees.Add(emp);

            Console.WriteLine("Employee Added Successfully.");
        }

        public void ShowEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No Employees Found.");
                return;
            }

            foreach (Employee emp in employees)
            {
                Console.WriteLine(
                    $"\nCode: {emp.EmployeeCode}" +
                    $"\nEmail: {emp.Email}" +
                    $"\nDepartment: {emp.Department}" +
                    $"\nExperience: {emp.ExperienceYears} Years");
            }
        }

        public void UpdateEmployee()
        {
            Console.Write("Enter Employee Code: ");
            string code = Console.ReadLine() ?? string.Empty;

            Employee? emp =
                employees.Find(e => e.EmployeeCode == code);

            if (emp == null)
            {
                Console.WriteLine("Employee Not Found.");
                return;
            }

            Console.Write("New Email: ");
            emp.Email = Console.ReadLine() ?? string.Empty;

            Console.Write("New Department: ");
            emp.Department = Console.ReadLine() ?? string.Empty;

            Console.Write("New Experience Years: ");
            emp.ExperienceYears =
                Convert.ToDouble(Console.ReadLine() ?? "0");

            Console.WriteLine("Employee Updated.");
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Code: ");
            string code = Console.ReadLine() ?? string.Empty;

            Employee? emp =
                employees.Find(e => e.EmployeeCode == code);

            if (emp == null)
            {
                Console.WriteLine("Employee Not Found.");
                return;
            }

            employees.Remove(emp);

            Console.WriteLine("Employee Deleted.");
        }
    }
}