using DataAccessLayer.Models;
using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<List<EmployeeDto>> GetEmployees()
        {
            // return TempData.Data;
            using (EmployeeDbContext dbContext = new EmployeeDbContext())
            {
                var employees = await dbContext.Employees.ToListAsync();

                List<EmployeeDto> domainModels = new List<EmployeeDto>();
                // For reading convert dbModel to domain model 
                foreach (var emp in employees)
                {
                    domainModels.Add(new EmployeeDto
                    {
                        Id = emp.Id,
                        Name = emp.Name,
                        Salary = (int)emp.Salary,
                        DepartmentId = emp.DepartmentId
                    });
                }
                return domainModels;

            }
        }

        public async Task InsertEmployee(EmployeeDto employee)
        {
            // TempData.Data.Add(employee);
            using (EmployeeDbContext dbContext = new EmployeeDbContext())
            {
                // For inserting convert domain model to dbmodel 

                var dbModel = new Employee
                {
                    Name = employee.Name,
                    Salary = employee.Salary,
                    DepartmentId = employee.DepartmentId
                };

                dbContext.Employees.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployee(EmployeeDto employee)
        {

            using (EmployeeDbContext dbContext = new EmployeeDbContext())
            {
                var findEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);

                findEmployee.Name = employee.Name;
                findEmployee.Salary = employee.Salary;

                dbContext.Employees.Update(findEmployee);
                await dbContext.SaveChangesAsync();
            }

            //foreach (var emp in TempData.Data)
            //{
            //  if (emp.Id == employee.Id)
            // {
            //   emp.Name = employee.Name;
            // emp.Salary = employee.Salary;
            //}
            //}
        }

        public async Task DeleteEmployee(int id)
        {
            //  TempData.Data = TempData.Data.Where(x => x.Id != id).ToList();
            using (EmployeeDbContext dbContext = new EmployeeDbContext())
            {
                var findEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Employees.Remove(findEmployee);
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            // return TempData.Data.Find(x => x.Id == id);
            // return TempData.Data.FirstOrDefault(x => x.Id == id);


            using (EmployeeDbContext dbContext = new EmployeeDbContext())
            {
                var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

                EmployeeDto domainModel = new EmployeeDto
                {
                    DepartmentId = employee.DepartmentId,
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = (int)employee.Salary
                };

                return domainModel;

            }

        }
    }
}
