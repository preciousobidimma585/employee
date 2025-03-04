namespace EmployeePayrollSystem.Domain
{
    public class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public string Department { get; }
        public double Salary { get; }
        public double TaxRate { get; } = 0.1;  // 10% Default Tax Rate

        public Employee(int id, string name, string department, double salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }

        public double CalculateNetSalary()
        {
            return Salary - (Salary * TaxRate);
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Dept: {Department}, Salary: {Salary:C}, Net Salary: {CalculateNetSalary():C}";
        }
    }
}