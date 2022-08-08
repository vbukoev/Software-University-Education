using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string healthPattern = @"[^\+\-\*\/\.,0-9]";
            string damagePattern = @"-?\d+\.?\d*";
            string multiplyOrDividePattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";
            string[] demons = Regex.Split(input, splitPattern).OrderBy(x=>x).ToArray();

            for (int i = 0; i < demons.Length; i++)
            {
                string curDemon = demons[i];
                var healthMatched = Regex.Matches(curDemon, healthPattern);
                var health = 0;
                foreach (Match match in healthMatched)
                {
                    char curChr = char.Parse(match.ToString());
                    health += curChr;
                }
                double damage = 0;
                var damageMatched = Regex.Matches(curDemon, damagePattern);
                foreach (Match match in damageMatched)
                {
                    double curDamage = double.Parse(match.ToString());
                    damage += curDamage;
                }
                var multiplyOrDivide = Regex.Matches(curDemon, multiplyOrDividePattern);
                foreach (Match match in multiplyOrDivide)
                {
                    char curOpperator = char.Parse(match.ToString());
                    if (curOpperator == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{curDemon} - {health} health, {damage:f2} damage");
            }
        }
    }
}
