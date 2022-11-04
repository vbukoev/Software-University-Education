namespace BirthdayCelebrations.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Command
    {
        public Command (string name, string[] args)
        {
            Name = name;
            Args = args;
        }
        public string Name { get; private set; }
        public string[] Args { get; private set; }
    }
}
