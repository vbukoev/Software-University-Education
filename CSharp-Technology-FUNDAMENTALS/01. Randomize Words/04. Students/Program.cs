using System;
using System.Collections.Generic;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end") break;
                string[] studentPr = command.Split(' ');
                Student student = new Student
                {
                    FirstName = studentPr[0],
                    LastName = studentPr[1],
                    Age = int.Parse(studentPr[2]),
                    HomeTown = studentPr[3]
                };
                students.Add(student);
            }
            string homeName = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == homeName)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
                
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        
    }
}
