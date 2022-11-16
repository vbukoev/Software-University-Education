namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsParts = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string command = argsParts[0];

            string[] commandArgs = argsParts.Skip(1).ToArray();

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == $"{command}Command")
                .FirstOrDefault();

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
