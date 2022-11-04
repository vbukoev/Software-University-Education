namespace MilitaryElite.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
