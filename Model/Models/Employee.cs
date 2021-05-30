using System;
using System.Collections.Generic;

namespace TestProject.Model.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex EmployeeSex { get; set; }
        public ICollection<Order> AllOrders { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }

    public enum Sex
    {
        Men,
        Woomen
    }
}