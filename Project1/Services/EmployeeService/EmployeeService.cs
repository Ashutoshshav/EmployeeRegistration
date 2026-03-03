using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ProjectDbContext _context;

        public EmployeeService(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<(List<Employee>, int)> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Employees.AsQueryable();

            int totalRecords = await query.CountAsync();

            var employees = await query
                .OrderBy(e => e.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (employees, totalRecords);
        }

        public async Task<Employee?> GetByIdAsync(int id)
            => await _context.Employees.FindAsync(id);

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
