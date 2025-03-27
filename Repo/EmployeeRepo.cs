using DolgozoProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProject.Repo
{
    public class EmployeeRepo
    {
        private readonly DolgozokContext _context = new();
        public EmployeeRepo()
        {
        }
        public int GetNumberOfEmployees()
        {
            return _context.Employees.Count();
        }
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public List<Employee> GetEmployeesAboveSalary(int salary)
        {
            return _context.Employees.Where(e => e.Salary > salary).ToList();
        }
        public List<Employee> OrderEmployeesBySalary()
        {
            return _context.Employees.OrderByDescending(e => e.Salary).ToList();
        }
        public Task GetAvgSalaryAndSumSalary()
        {
            return _context.Employees.Select(e => new { Avg = _context.Employees.Average(e => e.Salary), Sum = _context.Employees.Sum(e => e.Salary) }).ToListAsync();
        }
        public async Task<Dictionary<string, int>> GroupBySalary()
        {
            var d = new Dictionary<string, int>{
                    {"400000 Ft alatt",0 },
                    { "400000 - 500000 Ft között",0 },
                    { "500000 Ft felett",0 },
                };

            var employees = await _context.Employees.ToListAsync();
            foreach (var e in employees)
            {
                if (e.Salary < 400000)
                {
                    d["400000 Ft alatt"]++;
                }
                else if (e.Salary < 500000)
                {
                    d["400000 - 500000 Ft között"]++;
                }
                else
                {
                    d["500000 Ft felett"]++;
                }
            }
            return d;

        }
        public List<string> GetEmployeeTax()
        {
            return _context.Employees.Select(e =>  $"Név: {e.Name} - Adó: {e.Tax}ft").ToList();
        }
        public List<string> GetNumberOfPaycycle()
        {
            return _context.Employees.Select(e => $"Név: {e.Name} - Fizetések száma: {e.Paycycle}").ToList();
        }
        public void AddNewEmployee(string email, string name)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                employee = new Employee(name, email);
                _context.Employees.Add(employee);
                _context.SaveChangesAsync();     
            }
            else
            {
                throw new ArgumentException("Már van ilyen email című dolgozó!");
            }
        }
        public void ChangeEmployeeSalary(string email, int salary)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                throw new ArgumentException("Nincs ilyen email című dolgozó!");
            }
            employee.AddSalary(salary);
            _context.SaveChangesAsync();
        }
        public void DeleteEmployee(string email)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                throw new ArgumentException("Nincs ilyen email című dolgozó!");
            }
            _context.Employees.Remove(employee);
            _context.SaveChangesAsync();
        }



    }
}
