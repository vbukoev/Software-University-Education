namespace _01SquareRoot
{
    using System;
    
    public class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            try
            {
                if (number < 0)
                    throw new ArgumentException("Invalid number.");
                else
                    Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
