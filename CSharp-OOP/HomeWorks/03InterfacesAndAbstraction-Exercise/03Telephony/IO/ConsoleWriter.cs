namespace Telephony.IO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Telephony.IO.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
