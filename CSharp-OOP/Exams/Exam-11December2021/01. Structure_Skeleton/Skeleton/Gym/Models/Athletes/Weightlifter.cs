using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int initialStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, initialStamina, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            Stamina += 10;
        }
    }
}
