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
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)//
        {
            var boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)//
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy = null;

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if(delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)//
        {
            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (booth.CocktailMenu.Models.Any(x => x.Name == cocktailName)
                && booth.CocktailMenu.Models.Any(x => x.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (size == "Small" || size == "Middle" || size == "Large")
            {
                ICocktail cocktail;

                if (cocktailTypeName == "Hibernation")
                {
                    cocktail = new Hibernation(cocktailName, size);
                }
                else if (cocktailTypeName == "MulledWine")
                {
                    cocktail = new MulledWine(cocktailName, size);
                }
                else return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
                booth.CocktailMenu.AddModel(cocktail);
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)//
        {
            var booth = booths.Models.Where(x => x.IsReserved == false && x.Capacity >= countOfPeople).OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)//
        {
            string[] orders = order.Split("/");
            string itemTypeName = orders[0];
            string itemName = orders[1];
            int countOfOrderedPieces = int.Parse(orders[2]);

            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);


            if (itemTypeName != "Hibernation" || itemTypeName != "MulledWine" || itemTypeName != "Gingerbread" || itemTypeName != "Stolen") 
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if ((!booth.CocktailMenu.Models.Any(x => x.Name == itemName))
                && (booth.DelicacyMenu.Models.All(x => x.Name != itemName)))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }
            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                var sizeCocktail = orders[3];

                var item = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName && x.Size == sizeCocktail);

                if (item == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, sizeCocktail, itemName);
                }

                booth.UpdateCurrentBill(item.Price * countOfOrderedPieces);
            }
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                var item = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName);

                if (item == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(item.Price * countOfOrderedPieces);
            }

            return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);
        }

        public string LeaveBooth(int boothId)//
        {
            var booth = booths.Models.FirstOrDefault(x=>x.BoothId == boothId);
            booth.Charge();
            var currentBill = booth.CurrentBill + booth.Turnover;
            if (booth.IsReserved)
            {
                booth.ChangeStatus();
            }
            
            return $"Bill {currentBill:f2} lv" + Environment.NewLine + $"Booth {boothId} is now available!";
        }

        public string BoothReport(int boothId)//
            => booths.Models.FirstOrDefault(x=>x.BoothId == boothId).ToString();
    }
}
