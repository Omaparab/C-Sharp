using EmployeeManagement.Models;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace EmployeeManagement.Services
{
    public class Employee_Service
    {
        private readonly ServiceClient client;

        public Employee_Service()
        {
            DataverseService ds = new DataverseService();
            client = ds.Connect();
        }

        public void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Employee Code: ");
            emp.EmployeeCode = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            emp.Email = Console.ReadLine() ?? "";

            Console.Write("Department: ");
            emp.Department = Console.ReadLine() ?? "";

            Console.Write("Experience Years: ");
            emp.ExperienceYears =
                Convert.ToDouble(Console.ReadLine() ?? "0");

            Entity employee = new Entity("cra32_employee");

            employee["cra32_name"] = emp.EmployeeCode;
            employee["cra32_employeecode"] = emp.EmployeeCode;
            employee["cra32_email"] = emp.Email;
            employee["cra32_department"] = emp.Department;
            employee["cra32_experienceyears"] =
                (decimal)emp.ExperienceYears;

            client.Create(employee);

            Console.WriteLine("Employee Added Successfully.");
        }

        public void ShowEmployees()
        {
            QueryExpression query =
                new QueryExpression("cra32_employee");

            query.ColumnSet =
                new ColumnSet(
                    "cra32_employeecode",
                    "cra32_email",
                    "cra32_department",
                    "cra32_experienceyears");

            var result =
                client.RetrieveMultiple(query);

            if (result.Entities.Count == 0)
            {
                Console.WriteLine("No Employees Found.");
                return;
            }

            foreach (var emp in result.Entities)
            {
                Console.WriteLine(
                    $"\nCode: {emp.GetAttributeValue<string>("cra32_employeecode")}" +
                    $"\nEmail: {emp.GetAttributeValue<string>("cra32_email")}" +
                    $"\nDepartment: {emp.GetAttributeValue<string>("cra32_department")}" +
                    $"\nExperience: {emp.GetAttributeValue<decimal?>("cra32_experienceyears")} Years");
            }
        }

        public void UpdateEmployee()
        {
            Console.Write("Enter Employee Code: ");
            string code = Console.ReadLine() ?? "";

            QueryExpression query =
                new QueryExpression("cra32_employee");

            query.ColumnSet =
                new ColumnSet(true);

            query.Criteria.AddCondition(
                "cra32_employeecode",
                ConditionOperator.Equal,
                code);

            var result =
                client.RetrieveMultiple(query);

            if (result.Entities.Count == 0)
            {
                Console.WriteLine("Employee Not Found.");
                return;
            }

            Entity employee = result.Entities[0];

            Console.Write("New Email: ");
            employee["cra32_email"] =
                Console.ReadLine() ?? "";

            Console.Write("New Department: ");
            employee["cra32_department"] =
                Console.ReadLine() ?? "";

            Console.Write("New Experience Years: ");
            employee["cra32_experienceyears"] =
                Convert.ToDecimal(Console.ReadLine() ?? "0");

            client.Update(employee);

            Console.WriteLine("Employee Updated.");
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Code: ");
            string code = Console.ReadLine() ?? "";

            QueryExpression query =
                new QueryExpression("cra32_employee");

            query.ColumnSet =
                new ColumnSet(false);

            query.Criteria.AddCondition(
                "cra32_employeecode",
                ConditionOperator.Equal,
                code);

            var result =
                client.RetrieveMultiple(query);

            if (result.Entities.Count == 0)
            {
                Console.WriteLine("Employee Not Found.");
                return;
            }

            client.Delete(
                "cra32_employee",
                result.Entities[0].Id);

            Console.WriteLine("Employee Deleted.");
        }
    }
}