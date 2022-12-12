using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        private CocktailRepository cocktails;
        private DelicacyRepository delicacies;

        public Controller()
        {
            booths = new BoothRepository();
            cocktails = new CocktailRepository();
            delicacies = new DelicacyRepository();
        }
        public string AddBooth(int capacity)
        {
            var boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;
            if (delicacyName == default)
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }
            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            delicacies.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail;
            if (cocktailName == default && size==default)
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }
            if (cocktailTypeName == "Hibernation")
            {
                if (size != "Small" && size != "Middle" && size != "Large")
                {
                    return $"{size} is not recognized as valid cocktail size!";
                }
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                if (size != "Small" && size != "Middle" && size != "Large")
                {
                    return $"{size} is not recognized as valid cocktail size!";
                }
                cocktail = new MulledWine(cocktailName, size);
            }
            else return $"Cocktail type {cocktailTypeName} is not supported in our application!";

            cocktails.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            throw new NotImplementedException();
        }

        public string TryOrder(int boothId, string order)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }
    }
}
