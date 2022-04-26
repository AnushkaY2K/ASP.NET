using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task InsertEmployee(Employee employee);
        public Task UpdateEmployee(Employee employee);
        public Task DeleteEmployee(int id);
        
    }
}
