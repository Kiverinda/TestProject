using System;

namespace TestProject.Model.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string Сounterparty { get; set; }
        public DateTime Date { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}