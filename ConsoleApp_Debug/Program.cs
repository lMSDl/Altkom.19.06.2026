class Employee
{
    public string Name { get; set; }
    public int HoursWorked { get; set; }
    public decimal HourlyRate { get; set; }
}

class Program
{
    static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "Anna", HoursWorked = 160, HourlyRate = 50 },
            new Employee { Name = "Tom", HoursWorked = 120, HourlyRate = 40 },
            new Employee { Name = "Kate", HoursWorked = 100, HourlyRate = 60 }
        };

        decimal totalPayroll = CalculatePayroll(employees);
        Console.WriteLine($"Total payroll: {totalPayroll}");

        var highestPaid = FindHighestPaidEmployee(employees);
        Console.WriteLine($"Highest paid employee: {highestPaid.Name}");

        PrintEmployee(employees, 0);
    }

    static decimal CalculatePayroll(List<Employee> employees)
    {
        decimal total = 0;

        foreach (var employee in employees)
        {
            total += employee.HoursWorked * employee.HourlyRate;
        }

        return total;
    }

    static Employee FindHighestPaidEmployee(List<Employee> employees)
    {
        Employee highestPaid = null;

        foreach (var employee in employees)
        {
            if (highestPaid == null ||
                employee.HourlyRate > highestPaid.HourlyRate)
            {
                highestPaid = employee;
            }
        }

        return highestPaid;
    }

    static void PrintEmployee(List<Employee> employees, int index)
    {
        Console.WriteLine($"Employee: {employees[index].Name}");
    }
}