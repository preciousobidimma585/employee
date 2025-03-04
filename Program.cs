using System;
using EmployeePayrollSystem.Application.Interfaces;
using EmployeePayrollSystem.Application.UseCases;
using EmployeePayrollSystem.Domain;
using Employee = EmployeePayrollSystem.Domain.Employee;

class Program
{
    static void Main()
    {
        IEmployeePayrollService payrollService = new EmployeePayrollService();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nWelcome to Employee Payroll System!");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Get Employee by ID");
            Console.WriteLine("3. Show All Employees");
            Console.WriteLine("4. Calculate Total Payroll");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee(payrollService);
                    break;
                case "2":
                    GetEmployeeById(payrollService);
                    break;
                case "3":
                    ShowAllEmployees(payrollService);
                    break;
                case "4":
                    CalculateTotalPayroll(payrollService);
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }

    static void AddEmployee(IEmployeePayrollService payrollService)
    {
        try
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Department: ");
            string department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine());

            var employee = new Employee(id, name, department, salary);
            payrollService.AddEmployee(employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void GetEmployeeById(IEmployeePayrollService payrollService)
    {
        Console.Write("Enter Employee ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var employee = payrollService.GetEmployeeById(id);
            Console.WriteLine(employee != null ? employee.ToString() : "Employee not found.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid ID.");
        }
    }

    static void ShowAllEmployees(IEmployeePayrollService payrollService)
    {
        var employees = payrollService.GetAllEmployees();
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
        }
        else
        {
            employees.ForEach(emp => Console.WriteLine(emp));
        }
    }

    static void CalculateTotalPayroll(IEmployeePayrollService payrollService)
    {
        double totalPayroll = payrollService.CalculateTotalPayroll();
        Console.WriteLine($"Total Payroll (Net Salary): {totalPayroll:C}");
    }
}