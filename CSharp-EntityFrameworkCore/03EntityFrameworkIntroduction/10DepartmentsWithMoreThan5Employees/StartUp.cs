using System;
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
            string output = GetDepartmentsWthMoreThan5Employees(context);
            Console.WriteLine(output);
        }

        public static string GetDepartmentsWthMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new { e.FirstName, e.LastName, e.JobTitle })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList()
                }).ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");
                sb.Append(string.Join(Environment.NewLine,
                    department.Employees.Select(x => $"{x.FirstName} {x.LastName} - {x.JobTitle}")));
            }

            return sb.ToString().TrimEnd();
        }
    }
}