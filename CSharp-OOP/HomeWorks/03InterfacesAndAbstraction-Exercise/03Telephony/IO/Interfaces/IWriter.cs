namespace Telephony.IO.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);    
    }
}
