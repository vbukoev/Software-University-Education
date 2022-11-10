using System;
using System.Linq;

namespace _07Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split().ToArray();
            var name = $"{data[0]} {data[1]}";
            var adress = data[2];
            var town = data[3];
            var info = new Threeuple<string, string, string>(name, adress, town);
            Console.WriteLine(info);

            var beerData = Console.ReadLine().Split().ToArray();
            var beerName = beerData[0];
            var littersBeer = int.Parse(beerData[1]);
            var drunkOrNot = IsDrunk(beerData[2]);
            var beerInfo = new Threeuple<string, int, bool>(beerName, littersBeer, drunkOrNot);
            Console.WriteLine(beerInfo);
            
            var accountData= Console.ReadLine().Split().ToArray();
            
            var nameOfThePerson =  accountData[0] ;
            var accountBalance = double.Parse(accountData[1]);  
            var bankName = accountData[2];
            var accountBalanceInformation = new Threeuple<string, double, string>(nameOfThePerson, accountBalance, bankName);
            Console.WriteLine(accountBalanceInformation);

        }

        public static bool IsDrunk(string input)
        {
            if (input == "drunk")
            {
                return true;
            }
            return false;
        }
    }
}
