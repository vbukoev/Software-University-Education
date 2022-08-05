using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nNumOfStuds = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < nNumOfStuds; i++)
            {
                string[] currStudsInf= Console.ReadLine().Split (' ');
                var student = new Student(currStudsInf[0], currStudsInf[1], double.Parse(currStudsInf[2]));
                students.Add(student);
            }
           students =  students.OrderByDescending(currStudent => currStudent.Grade).ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}
