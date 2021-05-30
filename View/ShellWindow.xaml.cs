using System.Collections.ObjectModel;
using System.Windows;
using TestProject.Model.Models;
using TestProject.ViewModel;

namespace TestProject.View
{
    /// <summary>
    ///     Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow
    {
        private readonly IShellViewModel _viewModel;
        public ObservableCollection<Department> _departments;
        public ObservableCollection<Employee> _employees;
        public ObservableCollection<Order> _orders;

        public ShellWindow(IShellViewModel viewModel)
        {
            _viewModel = viewModel;
            _orders = _viewModel.GetOrders();
            _departments = _viewModel.GetDepartments();
            _employees = _viewModel.GetEmployees();
            InitializeComponent();
        }

        private void Orders_Loaded(object sender, RoutedEventArgs e)
        {
            Orders.ItemsSource = _orders;
        }

        private void Departments_Loaded(object sender, RoutedEventArgs e)
        {
            Departments.ItemsSource = _departments;
        }

        private void Employees_Loaded(object sender, RoutedEventArgs e)
        {
            Employees.ItemsSource = _employees;
        }

        private void FildsAddOrder_Loaded(object sender, RoutedEventArgs e)
        {
            FildsAddOrder.ItemsSource = new ObservableCollection<Order>();
        }

        private void FildsAddDepartment_Loaded(object sender, RoutedEventArgs e)
        {
            FildsAddDepartment.ItemsSource = new ObservableCollection<Department>();
        }

        private void FildsAddEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            FildsAddEmployee.ItemsSource = new ObservableCollection<Employee>();
        }

        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            var order = (sender as FrameworkElement)?.DataContext as Order;
            _viewModel.UpdateOrder(order);
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            var order = (sender as FrameworkElement)?.DataContext as Order;
            var result = _viewModel.RemoveOrder(order);
            if (result)
            {
                _orders.Remove(order);
                FildsAddOrder.ItemsSource = new ObservableCollection<Order>();
            }
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            var order = (sender as FrameworkElement)?.DataContext as Order;
            var result = _viewModel.AddOrder(order);
            if (result)
            {
                _orders.Add(order);
                FildsAddOrder.ItemsSource = new ObservableCollection<Order>();
            }
        }

        private void UpdateDepartment(object sender, RoutedEventArgs e)
        {
            var department = (sender as FrameworkElement)?.DataContext as Department;
            _viewModel.UpdateDepartment(department);
        }

        private void DeleteDepartment(object sender, RoutedEventArgs e)
        {
            var department = (sender as FrameworkElement)?.DataContext as Department;
            var result = _viewModel.RemoveDepartment(department);
            if (result)
            {
                _departments.Remove(department);
                FildsAddDepartment.ItemsSource = new ObservableCollection<Department>();
            }
        }

        private void AddDepartment(object sender, RoutedEventArgs e)
        {
            var department = (sender as FrameworkElement)?.DataContext as Department;
            var result = _viewModel.AddDepartment(department);
            if (result)
            {
                _departments.Add(department);
                FildsAddDepartment.ItemsSource = new ObservableCollection<Department>();
            }
        }

        private void UpdateEmployee(object sender, RoutedEventArgs e)
        {
            var employee = (sender as FrameworkElement)?.DataContext as Employee;
            _viewModel.UpdateEmployee(employee);
        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            var employee = (sender as FrameworkElement)?.DataContext as Employee;
            var result = _viewModel.RemoveEmployee(employee);
            if (result)
            {
                _employees.Remove(employee);
                FildsAddEmployee.ItemsSource = new ObservableCollection<Employee>();
            }
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            var employee = (sender as FrameworkElement)?.DataContext as Employee;
            var result = _viewModel.AddEmployee(employee);
            if (result)
            {
                _employees.Add(employee);
                FildsAddEmployee.ItemsSource = new ObservableCollection<Employee>();
            }
        }
    }
}