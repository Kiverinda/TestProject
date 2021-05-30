using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestProject.Annotations;
using TestProject.Model.Models;
using TestProject.Model.Repo.Interfaces;

namespace TestProject.ViewModel
{
    public class ShellViewModel : IShellViewModel, INotifyPropertyChanged
    {
        private readonly IDepartmentRepo _department;
        private readonly IEmployeeRepo _employee;
        private readonly IOrderRepo _order;

        public ShellViewModel(IDepartmentRepo department, IEmployeeRepo employee, IOrderRepo order)
        {
            _department = department;
            _employee = employee;
            _order = order;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Order> GetOrders()
        {
            var orders = _order.GetItems();
            return orders;
        }

        public ObservableCollection<Department> GetDepartments()
        {
            var departments = _department.GetItems();
            return departments;
        }

        public ObservableCollection<Employee> GetEmployees()
        {
            var employees = _employee.GetItems();
            return employees;
        }

        public bool RemoveOrder(Order order)
        {
            _order.Delete(order.OrderId);
            return true;
        }

        public bool RemoveDepartment(Department department)
        {
            _department.Delete(department.DepartmentId);
            return true;
        }

        public bool RemoveEmployee(Employee employee)
        {
            _employee.Delete(employee.EmployeeId);
            return true;
        }

        public bool AddOrder(Order order)
        {
            _order.Add(order);
            return true;
        }

        public bool AddDepartment(Department department)
        {
            _department.Add(department);
            return true;
        }

        public bool AddEmployee(Employee employee)
        {
            _employee.Add(employee);
            return true;
        }

        public bool UpdateOrder(Order order)
        {
            _order.Update(order);
            return true;
        }

        public bool UpdateDepartment(Department department)
        {
            _department.Update(department);
            return true;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _employee.Update(employee);
            return true;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}