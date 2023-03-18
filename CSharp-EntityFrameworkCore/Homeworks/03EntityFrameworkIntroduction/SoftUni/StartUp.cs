using SoftUni.Data;
using System.Text;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        string result = GetEmployeesFullInformation(dbContext);
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
}
