using System.Globalization;
using SoftUni.Data;
using System.Text;
using SoftUni.Models;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        string result = GetEmployeesInPeriod(dbContext);
        Console.WriteLine(result);
    }

    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allEmployees = context
            .Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToList();
        foreach (var employee in allEmployees)
        {
            output.AppendLine(
                $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }
        return output.ToString().TrimEnd();
    }

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allEmployees = context
            .Employees
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToList();
        foreach (var employee in allEmployees)
        {
            output.AppendLine(
                $"{employee.FirstName} - {employee.Salary:f2}");
        }
        return output.ToString().TrimEnd();
    }

    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allEmployees = context
            .Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Department.Name,
                e.Salary
            })
            .ToList();
        foreach (var employee in allEmployees)
        {
            output.AppendLine(
                $"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
        }
        return output.ToString().TrimEnd();
    }

    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };
        Employee nakov = context
            .Employees
            .FirstOrDefault(e => e.LastName == "Nakov");
        nakov.Address = newAddress;
        context.SaveChanges();

        StringBuilder output = new StringBuilder();
        string[] addresses = context
            .Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText)
            .ToArray();
        foreach (var adrText in addresses)
        {
            output.AppendLine(adrText);
        }
        return output.ToString().TrimEnd();
    }

    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employees = context.Employees
            .Where(e=>e.Projects.Any(p=>p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
            .Select(e=>new { e.FirstName, e.LastName, e.Projects, e.ManagerId })
            .Take(10)
            .ToList();

        foreach (var employee in employees)
        {
            var manager = context.Employees.First(e => e.EmployeeId == employee.ManagerId);
            sb.AppendLine(
                $"{employee.FirstName} {employee.LastName} - Manager: {manager.FirstName} {manager.LastName}");
            foreach (var project in employee.Projects)
            {
                var endDateProject = project.EndDate != null
                 ? (project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))
                 : "not finished";
                var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                sb.AppendLine($"--{project.Name} - {startDate} - {endDateProject}");
            }
        }
        return sb.ToString().TrimEnd();
    }
}
