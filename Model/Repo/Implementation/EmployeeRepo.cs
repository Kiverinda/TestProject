using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Model.Ef;
using TestProject.Model.Models;
using TestProject.Model.Repo.Interfaces;

namespace TestProject.Model.Repo.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly TestDbContext _context;

        public EmployeeRepo(TestDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == id);
            return employee;
        }

        public ObservableCollection<Employee> GetItems()
        {
            return new(_context.Employees.ToList());
        }

        public async Task Add(Employee item)
        {
            item.EmployeeId = new Guid();
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee item)
        {
            _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}