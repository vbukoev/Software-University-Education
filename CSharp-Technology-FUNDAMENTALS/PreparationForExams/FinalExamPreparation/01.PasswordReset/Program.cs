using System;
using System.Text;

namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder(); // stringBuilder
            var cmd = "";
            while (true)
            {
                cmd = Console.ReadLine();
                if (cmd == "Done") break;
                var command = cmd.Split();
                var action = command[0];
                switch (action)
                {
                    case "TakeOdd":
                        for (int i = 1; i < input.Length; i+=2) sb.Append(input[i]); //index "i" has to be with step of 2 so that it will get only the odd indices
                        input= sb.ToString();
                        Console.WriteLine(input);
                        break;
                    case "Cut":
                        var index = int.Parse(command[1]);
                        var length = int.Parse(command[2]);
                        input = input.Remove(index, length);
                        Console.WriteLine(input);
                        break;
                    case "Substitute":
                        var oldC = command[1];
                        var newC = command[2];
                        if (!input.Contains(oldC)) 
                            Console.WriteLine("Nothing to replace!");
                        else
                        {
                            input = input.Replace(oldC, newC);
                            Console.WriteLine(input);
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Your password is: {input}");
        }
    }
}
