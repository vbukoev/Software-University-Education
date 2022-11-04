namespace MilitaryElite.Models
{
    using Enums;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; private set; }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corps.ToString()}";
        }
    }
}
