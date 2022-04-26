
using DataAccessLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBusiness(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        public async Task InsertEmployee(Employee employee)
        {
            await _employeeRepository.InsertEmployee(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
        }
    }
}
