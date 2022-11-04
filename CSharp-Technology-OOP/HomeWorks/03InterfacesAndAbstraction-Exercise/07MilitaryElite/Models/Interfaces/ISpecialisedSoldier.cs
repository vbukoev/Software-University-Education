namespace MilitaryElite.Models.Interfaces
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
