﻿namespace MilitaryElite.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
