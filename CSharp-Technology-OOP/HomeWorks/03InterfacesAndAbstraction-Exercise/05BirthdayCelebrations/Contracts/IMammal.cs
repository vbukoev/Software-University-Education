namespace BirthdayCelebrations.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IMammal
    {
        string Name { get; }
        string Birthdate { get; }
    }
}
