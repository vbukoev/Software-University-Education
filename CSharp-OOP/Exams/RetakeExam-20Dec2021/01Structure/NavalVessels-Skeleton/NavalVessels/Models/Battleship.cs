using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private const double InitialArmour = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness) : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed += 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed -= 5;
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
             =>base.ToString() + Environment.NewLine + $" *Sonar mode: {(SonarMode ? "ON" : "OFF")}";
    }
}
