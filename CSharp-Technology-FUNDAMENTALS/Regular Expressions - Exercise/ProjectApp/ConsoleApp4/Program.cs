using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    //getters
    public string getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    //setters
    public void setNum(String newNum)
    {
        cardNum = newNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exitt");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you! Your new balance is: " + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() > withdrawal)
                Console.WriteLine("Insufficient balance!");
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you for the withdrawal! Have a nice day!");
            }           
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        // database with cardHolders
        cardHolders.Add(new cardHolder("4124384718598783", 1234, "Tamika", "Williamson", 1432.43));
        cardHolders.Add(new cardHolder("4572828901388201", 9832, "Rosa", "Oyler", 32413.73));
        cardHolders.Add(new cardHolder("5136653994882779", 5432, "James", "Hansen", 132312.21));
        cardHolders.Add(new cardHolder("4576149086779833", 3242, "Justin", "Cortright", 31231.31));
        cardHolders.Add(new cardHolder("5486461688406210", 9999, "Loreta", "Jameson", 753.92));
        
        Console.WriteLine("Welcome to ATM!");
        Console.WriteLine("Please insert your card: ");
        String debitCardNum = "";
        cardHolder currentUser;
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);// added LinQ method
                if (currentUser != null) break;
                else Console.WriteLine("Card not recognized. Please try again later!");
            }
            catch { Console.WriteLine("Card not recognized. Please try again later!"); }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                
                if (currentUser.getPin() == userPin) break;
                else Console.WriteLine("Incorrect pin! Please try again later!");
            }
            catch { Console.WriteLine("Incorrect pin! Please try again later!"); }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());

            }
            catch { }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            } 
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else 
            { 
                option = 0; 
            }
        } 
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day!");
    } 
}