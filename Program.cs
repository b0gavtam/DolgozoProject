using DolgozoProject.Models;
using DolgozoProject.Repo;

try
{
	Employee bademployee = new("a", "");
}
catch (Exception e)
{

    Console.WriteLine(e.Message);
}
Employee anna = new("Nagy Anna", "nagy.anna@munkahely.com");
try
{
    anna.AddSalary(-50000);
}
catch (Exception e)
{

    Console.WriteLine(e.Message);
}
anna.AddSalary(250000);
anna.AddSalary(400000);
Console.WriteLine(anna.ToString());

EmployeeRepo repo = new();
Console.WriteLine(repo.GetNumberOfEmployees());
foreach (var item in repo.GetEmployees())
{
    Console.WriteLine(item);
}

foreach (var item in repo.GetEmployeesAboveSalary(480000))
{
    Console.WriteLine(item);
}
foreach (var item in repo.OrderEmployeesBySalary())
{
    Console.WriteLine(item);
}

Console.WriteLine(repo.GetAvgSalaryAndSumSalary());

foreach (var item in repo.GetEmployeeTax())
{
    Console.WriteLine(item);
}
foreach (var item in repo.GetNumberOfPaycycle())
{
    Console.WriteLine(item);
}
