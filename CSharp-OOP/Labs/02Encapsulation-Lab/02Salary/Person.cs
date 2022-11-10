using Microsoft.VisualBasic;

namespace PersonsInfo
{
    public class Person 
    {
        //Salary: decimal 
        //IncreaseSalary(decimal percentage)  
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
        
        public void IncreaseSalary(decimal percentage)
        {
            if (Age<30)
            {
                percentage /= 2;
            }
            Salary += Salary * percentage / 100;
        }
    }
}