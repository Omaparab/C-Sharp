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

            Console.Write("Department Name: ");
            string departmentName = Console.ReadLine() ?? "";

            Console.Write("Experience Years: ");
            emp.ExperienceYears =
                Convert.ToDouble(Console.ReadLine() ?? "0");

            QueryExpression deptQuery =
                new QueryExpression("oma_department");

            deptQuery.ColumnSet =
                new ColumnSet("oma_name");

            deptQuery.Criteria.AddCondition(
                "oma_name",
                ConditionOperator.Equal,
                departmentName);

            var deptResult =
                client.RetrieveMultiple(deptQuery);

            if (deptResult.Entities.Count == 0)
            {
                Console.WriteLine("Department Not Found.");
                return;
            }

            Entity employee = new Entity("oma_employee");

            employee["oma_name"] = emp.EmployeeCode;
            employee["oma_employeecode"] = emp.EmployeeCode;
            employee["oma_email"] = emp.Email;
            employee["oma_department"] =
                new EntityReference(
                    "oma_department",
                    deptResult.Entities[0].Id);

            employee["oma_experienceyears"] =
                (decimal)emp.ExperienceYears;

            client.Create(employee);

            Console.WriteLine("Employee Added Successfully.");
        }

        public void ShowEmployees()
        {
            QueryExpression query =
                new QueryExpression("oma_employee");

            query.ColumnSet =
                new ColumnSet(
                    "oma_employeecode",
                    "oma_email",
                    "oma_department",
                    "oma_experienceyears");

            var result =
                client.RetrieveMultiple(query);

            if (result.Entities.Count == 0)
            {
                Console.WriteLine("No Employees Found.");
                return;
            }

            foreach (var emp in result.Entities)
            {
                EntityReference department =
                    emp.GetAttributeValue<EntityReference>("oma_department");

                Console.WriteLine(
                    $"\nCode: {emp.GetAttributeValue<string>("oma_employeecode")}" +
                    $"\nEmail: {emp.GetAttributeValue<string>("oma_email")}" +
                    $"\nDepartment: {department?.Name}" +
                    $"\nExperience: {emp.GetAttributeValue<decimal?>("oma_experienceyears")} Years");
            }
        }

        public void UpdateEmployee()
        {
            Console.Write("Enter Employee Code: ");
            string code = Console.ReadLine() ?? "";

            QueryExpression query =
                new QueryExpression("oma_employee");

            query.ColumnSet =
                new ColumnSet(true);

            query.Criteria.AddCondition(
                "oma_employeecode",
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
            employee["oma_email"] =
                Console.ReadLine() ?? "";

            Console.Write("New Department Name: ");
            string departmentName =
                Console.ReadLine() ?? "";

            QueryExpression deptQuery =
                new QueryExpression("oma_department");

            deptQuery.ColumnSet =
                new ColumnSet("oma_name");

            deptQuery.Criteria.AddCondition(
                "oma_name",
                ConditionOperator.Equal,
                departmentName);

            var deptResult =
                client.RetrieveMultiple(deptQuery);

            if (deptResult.Entities.Count == 0)
            {
                Console.WriteLine("Department Not Found.");
                return;
            }

            employee["oma_department"] =
                new EntityReference(
                    "oma_department",
                    deptResult.Entities[0].Id);

            Console.Write("New Experience Years: ");

            employee["oma_experienceyears"] =
                Convert.ToDecimal(
                    Console.ReadLine() ?? "0");

            client.Update(employee);

            Console.WriteLine("Employee Updated.");
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Code: ");
            string code = Console.ReadLine() ?? "";

            QueryExpression query =
                new QueryExpression("oma_employee");

            query.ColumnSet =
                new ColumnSet(false);

            query.Criteria.AddCondition(
                "oma_employeecode",
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
                "oma_employee",
                result.Entities[0].Id);

            Console.WriteLine("Employee Deleted.");
        }
    }
}