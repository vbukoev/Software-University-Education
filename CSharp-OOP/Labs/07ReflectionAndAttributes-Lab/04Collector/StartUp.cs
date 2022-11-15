namespace Stealer
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var  result = spy.Collector("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }  
}
