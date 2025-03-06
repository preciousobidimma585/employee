
using EmployeePayrollSystem.Domain;

namespace EmployeePayrollSystem.Application.Interfaces
{
    public interface IEmployeePayrollService
    {
        void AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees();
        double CalculateTotalPayroll();
        //void AddEmployee(Domain.Employee employee);
    }

    
}