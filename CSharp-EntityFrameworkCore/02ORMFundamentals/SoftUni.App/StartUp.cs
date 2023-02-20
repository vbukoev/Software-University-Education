namespace SoftUni.App
{
    using System;
    using System.Linq;

    using Data;
    using Data.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniDbContext dbContext = 
                new SoftUniDbContext(Config.ConnectionString);

            Employee[] employedEmployees = dbContext
                .Employees
                .Where(e => e.IsEmployed)
                .ToArray();

            foreach (Employee e in employedEmployees)
            {
                Console.WriteLine($"{e.Id}. {e.FirstName} {e.LastName}");
            }

            //Console.WriteLine("Trying to add an Employee...");

            //Employee newEmployee = new Employee()
            //{
            //    FirstName = "Pesho",
            //    LastName = "Peshov",
            //    IsEmployed = false,
            //    DepartmentId = 1
            //};
            //dbContext.Employees.Add(newEmployee);
            //dbContext.SaveChanges();

            //Console.WriteLine("Success!");

            //Console.WriteLine("Trying to delete an Employee...");
            //Employee delete = dbContext
            //    .Employees
            //    .First(e => e.FirstName == "Pesho");
            //dbContext.Employees.Remove(delete);
            //dbContext.SaveChanges();

            //Console.WriteLine("Success!");

            //Console.WriteLine("Trying to update an Employee...");
            //Employee update = dbContext
            //    .Employees
            //    .First(e => e.FirstName == "Peter");
            //update.IsEmployed = true;
            //dbContext.SaveChanges();

            //Console.WriteLine("Success!");
        }
    }
}
