using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, int>();
            string cmd = Console.ReadLine();
            while (cmd != "Once upon a time")
            {
                var tokens = cmd.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                var dwarfName = tokens[0];
                var hatColor = tokens[1];
                var physics = int.Parse(tokens[2]);
                var dwarfID = $"{dwarfName}:{hatColor}";
                if (!dwarfs.ContainsKey(dwarfID)) dwarfs.Add(dwarfID, physics);
                else
                {
                    dwarfs[dwarfID] = Math.Max(dwarfs[dwarfID], physics);
                }
                cmd = Console.ReadLine();
            }
            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Value).ThenByDescending(currDwarf => dwarfs.Where(hatColor => hatColor.Key.Split(":")[1] == currDwarf.Key.Split(":")[1]).Count()))
            {
                string hatColor = dwarf.Key.Split(":")[1];
                string name = dwarf.Key.Split(":")[0];
                int dwarfPhysics = dwarf.Value;
                Console.WriteLine($"({hatColor}) {name} <-> {dwarfPhysics}");
            }
        }
    }
}
