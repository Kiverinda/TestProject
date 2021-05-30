using System.Collections.ObjectModel;
using TestProject.Model.Models;

namespace TestProject.ViewModel
{
    public interface IShellViewModel
    {
        ObservableCollection<Order> GetOrders();
        ObservableCollection<Department> GetDepartments();
        ObservableCollection<Employee> GetEmployees();
        bool RemoveOrder(Order order);
        bool RemoveDepartment(Department department);
        bool RemoveEmployee(Employee employee);
        bool AddOrder(Order order);
        bool AddDepartment(Department department);
        bool AddEmployee(Employee employee);
        bool UpdateOrder(Order order);
        bool UpdateDepartment(Department department);
        bool UpdateEmployee(Employee employee);
    }
}