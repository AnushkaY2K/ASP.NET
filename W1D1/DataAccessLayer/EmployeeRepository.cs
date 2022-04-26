using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<List<Employee>> GetEmployees()
        {
            return TempData.Data;
        }

        public async Task InsertEmployee(Employee employee)
        {
            TempData.Data.Add(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            foreach (var emp in TempData.Data)
            {
                if (emp.Id == employee.Id)
                {
                    emp.Name = employee.Name;
                    emp.Salary = employee.Salary;
                }
            }
        }

        public async Task DeleteEmployee(int id)
        {
            TempData.Data = TempData.Data.Where(x => x.Id != id).ToList();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            // return TempData.Data.Find(x => x.Id == id);
            return TempData.Data.FirstOrDefault(x => x.Id == id);
        }

      

        
    }
}
