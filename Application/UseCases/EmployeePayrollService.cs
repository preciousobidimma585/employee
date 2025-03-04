using EmployeePayrollSystem.Application.Interfaces;
using EmployeePayrollSystem.Domain;

namespace EmployeePayrollSystem.Application.UseCases
{
    internal class EmployeePayrollService : IEmployeePayrollService
    {
        private readonly Dictionary<int, Interfaces.Employee> _employees = new();

        public void AddEmployee(Interfaces.Employee employee)
        {
            if (_employees.ContainsKey(employee.Id))
            {
                Console.WriteLine("Error: Employee ID already exists.");
                return;
            }

            _employees.Add(employee.Id, employee);
            Console.WriteLine("Employee added successfully!");
        }

        public Interfaces.Employee? GetEmployeeById(int id)
        {
            return _employees.TryGetValue(id, out var employee) ? employee : null;
        }

        public List<Interfaces.Employee> GetAllEmployees()
        {
            return _employees.Values.ToList();
        }

        public double CalculateTotalPayroll()
        {
            return _employees.Values.Sum(emp => emp.CalculateNetSalary());
        }

        public void AddEmployee(Domain.Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}