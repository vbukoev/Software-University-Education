using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == "HappyBunny") bunny = new HappyBunny(bunnyName);
            else if (bunnyType == "SleepyBunny") bunny = new SleepyBunny(bunnyName);
            else throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);
            IEnumerable<IBunny> bunny = bunnies.Models.OrderByDescending(x => x.Energy).TakeWhile(x => x.Energy >= 50);
            if (!bunny.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IWorkshop workshop = new Workshop();
            foreach (var item in bunny)
            {
                workshop.Color(egg, item);
                if (item.Energy ==0)
                {
                    bunnies.Remove(item);
                }
            }

            if (egg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, egg.Name);
            }

            else return string.Format(OutputMessages.EggIsNotDone, egg.Name);

        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();
           int coloredEggs = eggs.Models.Where(x => x.IsDone()).Count();
           sb.AppendLine($"{coloredEggs} eggs are done!");
           sb.Append("Bunnies info:");
           foreach (var bunny in bunnies.Models)
           {
               sb.AppendLine();
               sb.AppendLine($"Name: {bunny.Name}");
               sb.AppendLine($"Energy: {bunny.Energy}");
               sb.Append($"Dyes: {bunny.Dyes.Where(x => !x.IsFinished()).Count()} not finished");
           }
           return sb.ToString().TrimEnd();
        }
    }
}
