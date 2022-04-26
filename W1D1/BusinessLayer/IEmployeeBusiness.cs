using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IEmployeeBusiness
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task InsertEmployee(Employee employee);
        public Task UpdateEmployee(Employee employee);
        public Task DeleteEmployee(int id);
    }
}
