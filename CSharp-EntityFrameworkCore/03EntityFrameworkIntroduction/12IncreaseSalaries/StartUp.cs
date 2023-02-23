using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SoftUni
{
    using Data;

    public class StartUp
    {
        static void Main()
        {
            var context = new SoftUniContext();
            string output = IncreaseSalaries(context);
            Console.WriteLine(output);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departmentsNames = new string[]
                { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employeesForSalaryIncrease = context.Employees
                .Where(e => departmentsNames.Contains(e.Department.Name))
                .ToArray();
            foreach (var employee in employeesForSalaryIncrease)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();
            string[] employeesInfo = context.Employees
                .Where(e => departmentsNames.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:f2})")
                .ToArray();

            return string.Join(Environment.NewLine, employeesInfo);
        }
    }
}