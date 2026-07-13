using EmployeeManagement.Models;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;


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
            Console.Write("Employee Code: ");
            string employeeCode = Console.ReadLine() ?? "";

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Department Name: ");
            string departmentName = Console.ReadLine() ?? "";

            Console.Write("Experience Years: ");
            decimal experienceYears = Convert.ToDecimal(Console.ReadLine() ?? "0");

            QueryExpression deptQuery = new QueryExpression("oma_department");
            deptQuery.ColumnSet = new ColumnSet("oma_departmentname"); // explicit, avoids implicit oma_name lookup

            deptQuery.Criteria.AddCondition(
                "oma_departmentname",
                ConditionOperator.Equal,
                departmentName);

            var deptResult = client.RetrieveMultiple(deptQuery);

            if (deptResult.Entities.Count == 0)
            {
                Console.WriteLine("Department Not Found.");
                return;
            }

            Entity employee = new Entity("oma_employee");

            // Set the employee primary name attribute.
            // Use the entered name rather than the code for the display name.
            employee["oma_name"] = name;

            employee["oma_employeecode"] = employeeCode;
            employee["oma_email"] = email;
            employee["oma_experienceyears"] = experienceYears;

            employee["oma_department"] = new EntityReference(
                "oma_department",
                deptResult.Entities[0].Id);

            client.Create(employee);

            Console.WriteLine("Employee Added.");
        }

        public void ShowEmployees()
        {
            QueryExpression query =
                new QueryExpression("oma_employee");

            query.ColumnSet =
                new ColumnSet(
                    "oma_employeecode",
                    "oma_name",
                    "oma_email",
                    "oma_department",
                    "oma_experienceyears");

            var result =
                client.RetrieveMultiple(query);

            if (result.Entities.Count == 0)
            {
                Console.WriteLine(
                    "No Employees Found.");
                return;
            }

            foreach (var emp in result.Entities)
            {
                EntityReference department = emp.GetAttributeValue<EntityReference>("oma_department");
                string deptName = department?.Name;
                // If the lookup's Name wasn't populated, retrieve department name explicitly.
                if (deptName == null && department != null)
                {
                    try
                    {
                        var d = client.Retrieve(department.LogicalName, department.Id, new ColumnSet("oma_departmentname"));
                        deptName = d.GetAttributeValue<string>("oma_departmentname");
                    }
                    catch
                    {
                        deptName = "(unknown)";
                    }
                }

                Console.WriteLine(
                    $"\nCode: {emp.GetAttributeValue<string>("oma_employeecode")}" +
                    $"\nName: {emp.GetAttributeValue<string>("oma_name")}" +
                    $"\nEmail: {emp.GetAttributeValue<string>("oma_email")}" +
                    $"\nDepartment: {deptName}" +
                    $"\nExperience: {emp.GetAttributeValue<decimal?>("oma_experienceyears")} Years");
            }
        }

        public void UpdateEmployee()
        {
            Console.Write("Enter Employee Code: ");
            string code =
                Console.ReadLine() ?? "";

            QueryExpression query =
                new QueryExpression("oma_employee");

            // Request only the employee attributes we need to update.
            // Avoid ColumnSet(true) because retrieving all attributes can cause
            // Dataverse to attempt to resolve related lookup display names
            // (which may reference attributes that don't exist on the target entity).
            query.ColumnSet =
                new ColumnSet(
                    "oma_employeecode",
                    "oma_email",
                    "oma_experienceyears",
                    "oma_name"
                );

            query.Criteria.AddCondition(
                "oma_employeecode",
                ConditionOperator.Equal,
                code);

            var result =
                client.RetrieveMultiple(query);

            if (result.Entities.Count == 0)
            {
                Console.WriteLine(
                    "Employee Not Found.");
                return;
            }

            Entity employee =
                result.Entities[0];

            Console.Write("New Email: ");
            employee["oma_email"] =
                Console.ReadLine() ?? "";

            Console.Write("New Name: ");
            employee["oma_name"] =
                Console.ReadLine() ?? "";

            Console.Write("New Department Name: ");
            string departmentName =
                Console.ReadLine() ?? "";

            QueryExpression deptQuery =
                new QueryExpression("oma_department");

            deptQuery.ColumnSet =
                new ColumnSet("oma_departmentname");

            deptQuery.Criteria.AddCondition(
                "oma_departmentname",
                ConditionOperator.Equal,
                departmentName);

            var deptResult =
                client.RetrieveMultiple(deptQuery);

            if (deptResult.Entities.Count == 0)
            {
                Console.WriteLine(
                    "Department Not Found.");
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

            Console.WriteLine(
                "Employee Updated.");
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Code: ");
            string code =
                Console.ReadLine() ?? "";

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
                Console.WriteLine(
                    "Employee Not Found.");
                return;
            }

            client.Delete(
                "oma_employee",
                result.Entities[0].Id);

            Console.WriteLine(
                "Employee Deleted.");
        }
    }
}