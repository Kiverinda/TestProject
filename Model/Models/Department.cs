using System;

namespace TestProject.Model.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public Guid EmployeeId { get; set; }
    }
}