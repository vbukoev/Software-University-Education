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
            string output = DeleteProjectById(context);
            Console.WriteLine(output);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesToDelete = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(employeesToDelete);
            var projectsToDelete = context.Projects.Where(p => p.ProjectId == 2);
            context.Projects.RemoveRange(projectsToDelete);
            context.SaveChanges();
            string[] projectNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();
            return string.Join(Environment.NewLine, projectNames);
        }
    }
}