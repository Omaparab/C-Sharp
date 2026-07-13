namespace EmployeeManagement.Models
{
    public class Employee
    {
        public string EmployeeCode { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Department { get; set; } = "";
        public double ExperienceYears { get; set; }
    }
}