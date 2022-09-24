using System;
using System.Collections.Generic;
using System.IO;

namespace DEMO
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true)) //boolean append which adds every time another sentence if it is "true". 
            {
                writer.Write("How ");
                writer.Write("are ");
                writer.Write("you");
                writer.Write("?");
            }
        }
    }
}
