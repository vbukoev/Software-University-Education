//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NavalVessels.Core.Contracts;
//using NavalVessels.Models;
//using NavalVessels.Models.Contracts;
//using NavalVessels.Repositories;
//using NavalVessels.Utilities.Messages;

//namespace NavalVessels.Core
//{
//    public class Controller : IController
//    {
//        private VesselRepository vessels;
//        private List<ICaptain> captains;

//        public Controller()
//        {
//            vessels = new VesselRepository();
//            captains = new List<ICaptain>();
//        }
//        public string HireCaptain(string fullName)//
//        {
//            ICaptain captain = new Captain(fullName);
//            if (captains.Any(x => x.FullName == fullName))
//            {
//                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
//            }
//            captains.Add(captain);
//            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
//        }

//        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)//
//        {
//            if (vessels.FindByName(name) != null)
//                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
//            if (vesselType != "Submarine" && vesselType != "Battleship")
//                return OutputMessages.InvalidVesselType;

//            IVessel vesselToProduce;
//            if (vesselType == "Submarine")
//                vesselToProduce = new Submarine(name, mainWeaponCaliber, speed);
//            else
//                vesselToProduce = new Battleship(name, mainWeaponCaliber, speed);

//            vessels.Add(vesselToProduce);
//            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
//        }

//        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)//
//        {
//            ICaptain captain = captains.Find(x => x.FullName == selectedCaptainName);
//            IVessel vessel = vessels.FindByName(selectedVesselName);

//            if (captain == null)
//            {
//                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
//            }

//            if (vessel == null)
//            {
//                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
//            }

//            if (vessel.Captain != null)
//            {
//                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
//            }

//            captain.AddVessel(vessel);
//            vessel.Captain = captain;
//            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
//        }

//        public string CaptainReport(string captainFullName)//
//            => captains.Find(x => x.FullName == captainFullName).Report();


//        public string VesselReport(string vesselName)//
//            => vessels.FindByName(vesselName).ToString();

//        public string ToggleSpecialMode(string vesselName)//
//        {
//            IVessel vessel = vessels.FindByName(vesselName);

//            if (vessel == null)
//            {
//                return string.Format(OutputMessages.VesselNotFound, vesselName);
//            }

//            if (vessel.GetType().Name == "Battleship")
//            {

//                (vessel as Battleship).ToggleSonarMode();
//                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
//            }
//            else
//            {
//                (vessel as Submarine).ToggleSubmergeMode();
//                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
//            }
//        }

//        public string AttackVessels(string attackingVesselName, string defendingVesselName)//
//        {
//            IVessel attacker = vessels.FindByName(attackingVesselName);
//            IVessel defender = vessels.FindByName(defendingVesselName);

//            if (attacker == null)
//            {
//                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
//            }
//            else if (defender == null)
//            {
//                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
//            }

//            if (attacker.ArmorThickness == 0)
//            {
//                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
//            }

//            if (defender.ArmorThickness == 0)
//            {
//                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
//            }

//            attacker.Attack(defender);
//            attacker.Captain.IncreaseCombatExperience();
//            defender.Captain.IncreaseCombatExperience();

//            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName,
//                defender.ArmorThickness);
//        }

//        public string ServiceVessel(string vesselName)//
//        {
//            IVessel vessel = vessels.FindByName(vesselName);
//            if (vesselName == null)
//            {
//                return string.Format(OutputMessages.VesselNotFound, vesselName);
//            }
//            vessel.RepairVessel();
//            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
//        }
//    }
//}

namespace NavalVessels.Core
{
    using Core.Contracts;
    using Models.Contracts;
    using NavalVessels.Models;
    using Repositories;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Utilities.Messages;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captainToAssign = captains.Find(x => x.FullName == selectedCaptainName);
            IVessel vesselForAssigning = vessels.FindByName(selectedVesselName);

            if (captainToAssign == null)
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);

            if (vesselForAssigning == null)
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);

            if (vesselForAssigning.Captain != null)
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);

            captainToAssign.AddVessel(vesselForAssigning);
            vesselForAssigning.Captain = captainToAssign;
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vessels.FindByName(attackingVesselName);
            IVessel defender = vessels.FindByName(defendingVesselName);

            if (attacker == null)
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            else if (defender == null)
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if (attacker.ArmorThickness == 0)
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            if (defender.ArmorThickness == 0)
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captainToReport = captains.Find(x => x.FullName == captainFullName);
            return captainToReport.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain newCaptain = new Captain(fullName);
            if (captains.Any(x => x.FullName == fullName))
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            captains.Add(newCaptain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            if (vesselType != "Submarine" && vesselType != "Battleship")
                return OutputMessages.InvalidVesselType;

            IVessel vesselToProduce;
            if (vesselType == "Submarine")
                vesselToProduce = new Submarine(name, mainWeaponCaliber, speed);
            else
                vesselToProduce = new Battleship(name, mainWeaponCaliber, speed);

            vessels.Add(vesselToProduce);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vesselToService = vessels.FindByName(vesselName);
            if (vesselToService == null)
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            vesselToService.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vesselToToggle = vessels.FindByName(vesselName);
            if (vesselToToggle == null)
                return String.Format(OutputMessages.VesselNotFound, vesselName);

            if (vesselToToggle.GetType().Name == "Battleship")
            {
                (vesselToToggle as Battleship).ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                (vesselToToggle as Submarine).ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            IVessel vesselToReport = vessels.FindByName(vesselName);
            return vesselToReport.ToString();
        }
    }
}
