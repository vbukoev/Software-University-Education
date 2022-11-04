using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; 
namespace Clock
{
    class prExclass
    {
        public void ShowTime()
        {
            for (; ; )
            {
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("\a");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            prExclass PC = new prExclass();
            ThreadStart TS = new ThreadStart(PC.ShowTime);
            Thread t = new Thread(TS);
            t.Start();
            Console.ReadLine();
        }
    }
}