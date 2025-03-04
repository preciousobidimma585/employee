
namespace EmployeePayrollSystem.Application.Interfaces
{
    public interface IEmployeePayrollService
    {
        void AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees();
        double CalculateTotalPayroll();
        void AddEmployee(Domain.Employee employee);
    }

    public class Employee
    {
        private string? name;
        private string? department;
        private double salary;

        public Employee(int id, string? name, string? department, double salary)
        {
            Id = id;
            this.name = name;
            this.department = department;
            this.salary = salary;
        }

        public int Id { get; internal set; }

        internal double CalculateNetSalary()
        {
            throw new NotImplementedException();
        }
    }
}