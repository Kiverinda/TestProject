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
    public class OrderRepo : IOrderRepo
    {
        private readonly TestDbContext _context;

        public OrderRepo(TestDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetItem(Guid id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(x => x.OrderId == id);
            return order;
        }

        public ObservableCollection<Order> GetItems()
        {
            return new(_context.Orders.ToList());
        }

        public async Task Add(Order item)
        {
            item.Date = DateTime.Now;
            item.OrderId = new Guid();
            await _context.Orders.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Order item)
        {
            _context.Orders.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(x => x.OrderId == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}