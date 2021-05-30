using System.Windows;
using TestProject.Model.Repo.Implementation;
using TestProject.Model.Repo.Interfaces;
using TestProject.View;
using TestProject.ViewModel;
using Unity;

namespace TestProject
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IShellViewModel, ShellViewModel>();
            container.RegisterType<IDepartmentRepo, DepartmentRepo>();
            container.RegisterType<IEmployeeRepo, EmployeeRepo>();
            container.RegisterType<IOrderRepo, OrderRepo>();

            var shellWindow = container.Resolve<ShellWindow>();
            shellWindow.Show();
        }
    }
}