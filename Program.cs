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

    private static void ShowAllEmployees(IEmployeePayrollService payrollService)
    {
        throw new NotImplementedException();
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

   

    static void CalculateTotalPayroll(IEmployeePayrollService payrollService)
    {
        double totalPayroll = payrollService.CalculateTotalPayroll();
        Console.WriteLine($"Total Payroll (Net Salary): {totalPayroll:C}");
    }
}

internal class Employee
{
    private int id;
    private string? name;
    private string? department;
    private double salary;

    public Employee(int id, string? name, string? department, double salary)
    {
        this.id = id;
        this.name = name;
        this.department = department;
        this.salary = salary;
    }
}

internal class EmployeePayrollService : IEmployeePayrollService
{
    public void AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public double CalculateTotalPayroll()
    {
        throw new NotImplementedException();
    }

    public object GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    public object GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }
}

internal interface IEmployeePayrollService
{
    void AddEmployee(Employee employee);
    double CalculateTotalPayroll();
    object GetAllEmployees();
    object GetEmployeeById(int id);
}