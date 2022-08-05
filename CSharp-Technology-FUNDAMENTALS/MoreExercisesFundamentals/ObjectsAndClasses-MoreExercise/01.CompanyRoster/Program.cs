using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            int numOfCycles = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfCycles; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                if (!departments.Any(departmentt => departmentt.NameOfDep == tokens[2]))
                { 
                    departments.Add(new Department(tokens[2])); 
                }
                departments.Find(departmenttt => departmenttt.NameOfDep == tokens[2]).NewEmployee(tokens[0], decimal.Parse(tokens[1]));
            }
            Department theBestDepartment = departments.OrderByDescending(d => d.TotalSalary / d.AllEmployees.Count()).First();
            Console.WriteLine($"Highest Average Salary: {theBestDepartment.NameOfDep}");
            foreach (var item in theBestDepartment.AllEmployees.OrderByDescending(employees => employees.Salary)) Console.WriteLine($"{item.Name} {item.Salary:f2}");//Jony 840.20
        }
    }
    class Employee
    {
       
        public string Name{ get; set; }
        public decimal Salary{ get; set; }
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }
    }
    class Department
    {
        public string NameOfDep { get; set; }
        public List<Employee> AllEmployees { get; set; }= new List<Employee>();
        public decimal TotalSalary { get; set; }
        public void NewEmployee (string nameOfEmplyee, decimal salaryOfEmployee)
        {
            TotalSalary += salaryOfEmployee;

            AllEmployees.Add(new Employee(nameOfEmplyee, salaryOfEmployee));
        }
        public Department(string departmentName) { NameOfDep = departmentName; }
    }
}
