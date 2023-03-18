namespace SoftUni.App.Data
{
    using Models;

    using MiniORM;

    public class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string connectionString) 
            : base(connectionString)
        {

        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<EmployeeProject> EmployeesProjects { get; set; }
    }
}
