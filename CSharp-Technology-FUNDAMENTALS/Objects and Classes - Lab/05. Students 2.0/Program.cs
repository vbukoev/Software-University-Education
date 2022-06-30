using System;
using System.Collections.Generic;

namespace _05._Students2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end") break;
                string[] studentPr = command.Split();                
                
                if (IsStudentExisting(studentPr[0], studentPr[1], students))
                {
                    Student student = students.Find(student => student.FirstName == studentPr[0] && student.LastName == studentPr[1]);
                    student.Age = int.Parse(studentPr[2]);
                    student.HomeTown = studentPr[3];
                }
                else
                {
                    Student student = new Student(studentPr[0], studentPr[1], int.Parse(studentPr[2]), studentPr[3]);
                    students.Add(student);
                }
            }
           
            string homeName = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == homeName) Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            } 
        } 
        static bool IsStudentExisting(string firstName, string lastName, List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName) return true;
            }
            return false;
        }
    }   
    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
