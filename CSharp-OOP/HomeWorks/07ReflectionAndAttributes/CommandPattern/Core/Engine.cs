namespace CommandPattern.Core
{
    using System;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter interpreter;

        public Engine(ICommandInterpreter interpreter)
        {
            this.interpreter = interpreter; 
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string result = interpreter.Read(input);

                Console.WriteLine(result);
            }
        }
    }
}