using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private const int InitialArmour = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness) : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed += 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed -= 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < InitialArmour)
            {
                ArmorThickness = InitialArmour;
            }
        }

        public override string ToString()
            => base.ToString() + Environment.NewLine + $" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}";
    }
}
