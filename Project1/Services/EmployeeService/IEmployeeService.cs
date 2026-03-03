using Project1.Models;

namespace Project1.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<(List<Employee> employees, int totalRecords)> GetPagedAsync(int page, int pageSize);
        Task<Employee?> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
