using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> students;
        //•	Capacity: int
        //•	Count: int – returns the number of students in the classroom
        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }
        public Classroom(int capacity)
        {
            Capacity = capacity;
            this.students = new List<Student>();
        }
        public string RegisterStudent(Student student)
        {
            if (Count != Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if (this.students.Any(x=>x.FirstName == firstName && x.LastName == lastName))
            {
                students.Remove(students.Find(x => x.FirstName == firstName && x.LastName == lastName));
                return $"Dismissed student {firstName} {lastName}";
            }
            else return "Student not found"; 
        }
        public string GetSubjectInfo(string subject)
        {
            if (!students.Any(x => x.Subject == subject)) return $"No students enrolled for the subject";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");
            foreach (var item in students.Where(x => x.Subject == subject)) sb.AppendLine($"{item.FirstName} {item.LastName}");
            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount() //int because returns the count as an integer
        {
            return Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return students.Find(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
