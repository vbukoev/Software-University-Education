namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _06FoodStorage.Contracts;
    using BorderControl.Contracts;
    using BorderControl.Models;
    using FoodStorage.Models;

    public class Engine
    {
        private readonly List<IBuyer> buyers;

        public Engine()
        {
           buyers = new List<IBuyer>();
        }
        public void Run()
        {
            var peopleCnt = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCnt; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (personInfo.Length == 3)
                {
                    var rebel = CreateRebel(personInfo);
                    buyers.Add(rebel);
                }
                else if (personInfo.Length == 4)
                {
                    var citizen = CreateCitizen(personInfo);
                    buyers.Add(citizen);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                var person = buyers.FirstOrDefault(x => x.Name == input);
                if(person!=null)
                {
                    person.BuyFood();
                }
            }
            var totalAmountOfFood = buyers.Sum(x => x.Food);
            Console.WriteLine(totalAmountOfFood);
        }

        private IBuyer CreateCitizen(string[] personInfo)
        {
            var citizenName = personInfo[0];
            var citizenAge = int.Parse(personInfo[1]);
            var citizenId = personInfo[2];
            var citizenBirthdate = personInfo[3];
            IBuyer citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
            return citizen;
        }

        private IBuyer CreateRebel(string[] personInfo)
        {
            var rebelName = personInfo[0];
            var rebelAge = int.Parse(personInfo[1]);
            var group = personInfo[2];
            IBuyer rebel = new Rebel(rebelName, rebelAge, group);
            return rebel;
        }

        
    }
}
