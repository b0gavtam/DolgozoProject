using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProject.Models
{
    public class Employee
    {
        private int _salary;
        private string _email;
        private int _paycycle;
        public Employee(string name, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("az email nem lehet üres!");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("a név nem lehet üres!");
            }
            _email = email;
            Name = name;
        }
        public string Name { get; set; } 
        public int Salary => _salary;
        public string Email => _email;
        public const double TaxKey = 0.2;
        public double Tax => _salary * TaxKey;
        public int Paycycle => _paycycle;

        public void AddSalary(int salary)
        {
            if (salary < 0)
            {
                throw new ArgumentException("a fizetés nem lehet negatív!");
            }
            _salary += salary;
            _paycycle++;
        }
        public override string ToString()
        {
            return $"Név: {Name} \n Email: {Email} \n Fizetés: {Salary} \n Adó: {Tax} \n Fizetési ciklusok száma: {Paycycle} \n";
        }
    }
}
