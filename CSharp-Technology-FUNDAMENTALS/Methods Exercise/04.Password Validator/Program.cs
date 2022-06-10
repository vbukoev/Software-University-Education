using System;

namespace _04.Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isPasswordLengthValid = ValidatePasswordLength(password);
            bool isPasswordContainsValidSymbols = ValidatePasswordText(password);
            bool isDigitInPasswordAtLeastTwo = ValidatePasswordDigit(password);
            if (!isPasswordLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!isPasswordContainsValidSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!isDigitInPasswordAtLeastTwo)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isDigitInPasswordAtLeastTwo && isPasswordContainsValidSymbols && isPasswordLengthValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool ValidatePasswordDigit(string password)
        {
            int count = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    count++;
                }
            }
            return count >= 2;
        }

        private static bool ValidatePasswordText(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidatePasswordLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }












        //static void Main(string[] args)
        //{

        //    string password = Console.ReadLine();
        //    bool isPasswordLengthValid = ValidatePasswordLength(password);            
        //    bool isPasswordContainingValidSymbols = ValidatePasswordText(password);
        //    bool isDigitInPasswordAtLeastTwo = ValidatePasswordDigit(password);
        //    if (!isPasswordContainingValidSymbols)
        //    {
        //        Console.WriteLine("Password must consist only of letters and digits");
        //    }
        //    if (!isPasswordLengthValid)
        //    {
        //        Console.WriteLine("Password must be between 6 and 10 characters");
        //    }
        //    if (!isDigitInPasswordAtLeastTwo)
        //    {
        //        Console.WriteLine("Password must have at least 2 digits");
        //    }
        //    if(isDigitInPasswordAtLeastTwo && isPasswordContainingValidSymbols && isPasswordLengthValid)
        //    {
        //        Console.WriteLine("Password is valid");
        //    }
        //}

        //private static bool ValidatePasswordDigit(string password)
        //{
        //    int cnt = 0;
        //    foreach (char symbol in password)
        //    {
        //        if (char.IsDigit(symbol))
        //        {
        //            cnt++;
        //        }
        //    }
        //    return cnt >= 2;
        //}

        //private static bool ValidatePasswordText(string password)
        //{
        //    foreach (char symbol in password)
        //    {
        //        if (!char.IsLetterOrDigit(symbol))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //private static bool ValidatePasswordLength(string password)
        //{
        //    return password.Length >=6 && password.Length <=10;
        //}
    }
}