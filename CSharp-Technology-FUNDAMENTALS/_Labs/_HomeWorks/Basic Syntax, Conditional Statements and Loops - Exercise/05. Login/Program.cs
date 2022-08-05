using System;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int value = username.Length - 1; value >= 0; value--)
            {
                password += (username[value]);
            }
            int cntOfWrongPasswords = 0;
            string inputPassword = Console.ReadLine();
            while (inputPassword != password)
            {
                cntOfWrongPasswords++;
                if (cntOfWrongPasswords > 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                Console.WriteLine("Incorrect password. Try again.");
                inputPassword = Console.ReadLine();
            }
            if (inputPassword == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
