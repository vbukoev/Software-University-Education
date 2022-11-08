using System;
using System.Collections.Generic;
using System.Linq;

namespace _06MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accountBalance = new Dictionary<int, double>();
            string[] tokens = Console.ReadLine().Split(',');
            for (int i = 0; i < tokens.Length; i++)
            {
                int account = int.Parse(tokens[i].Split('-').First());
                double balance = double.Parse(tokens[i].Split('-').Last());
                accountBalance.Add(account, balance);
            }

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input == "End") break;
                    string[] commands = input.Split();
                    string command = commands[0];
                    if (command != "Deposit" && command != "Withdraw")
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    int acc;
                    try
                    {
                        acc = int.Parse(commands[1]);
                        if (!accountBalance.ContainsKey(acc))
                        {
                            throw new FormatException();
                        }
                    }

                    catch (FormatException)
                    {
                        throw new ArgumentException("Invalid account!");
                    }
                    double money = double.Parse(commands[2]);
                    if (command == "Deposit")
                    {
                        accountBalance[acc] = accountBalance[acc] + money;
                    }
                    else if (command == "Withdraw")
                    {
                        if (money > accountBalance[acc])
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }
                        accountBalance[acc] = accountBalance[acc] - money;
                    }

                    Console.WriteLine($"Account {acc} has new balance: {accountBalance[acc]:f2}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                Console.WriteLine("Enter another command");
            }
        }
    }
}
