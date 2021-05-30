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
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly TestDbContext _context;

        public DepartmentRepo(TestDbContext context)
        {
            _context = context;
        }

        public async Task<Department> GetItem(Guid id)
        {
            var department = await _context.Departments.SingleOrDefaultAsync(x => x.DepartmentId == id);
            return department;
        }

        public ObservableCollection<Department> GetItems()
        {
            return new(_context.Departments.ToList());
        }

        public async Task Add(Department item)
        {
            item.DepartmentId = new Guid();
            await _context.Departments.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Department item)
        {
            _context.Departments.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var department = await _context.Departments.SingleOrDefaultAsync(x => x.DepartmentId == id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}