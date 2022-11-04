namespace MilitaryElite.Models.Interfaces
{
    using MilitaryElite.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMission
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
