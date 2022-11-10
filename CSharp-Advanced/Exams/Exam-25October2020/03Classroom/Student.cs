using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ClassroomProject
{
    public class Student
    {
        //•	FirstName: string
        //•	LastName: string
        //•	Subject: string
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public Student(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }
        public override string ToString()
        {
            return $"Student: First Name = {FirstName}, Last Name = {LastName}, Subject = {Subject}";
        }
    }
}
