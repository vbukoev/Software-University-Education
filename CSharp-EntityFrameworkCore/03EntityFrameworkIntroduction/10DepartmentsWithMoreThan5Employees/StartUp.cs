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
            string output = GetEmployee147(context);
            Console.WriteLine(output);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    JobTitle = a.JobTitle,
                    Projects = a.Projects
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects.OrderBy(a => a.Name))
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}