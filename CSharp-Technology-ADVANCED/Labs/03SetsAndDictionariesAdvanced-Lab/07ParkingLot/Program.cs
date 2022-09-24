using System;
using System.Collections.Generic;
using System.Linq;

namespace _07ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var plate = new HashSet<string>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END") break;
                string IO = input[0];
                string plateNum = input[1];
                switch (IO)
                {
                    case "IN":
                        plate.Add(plateNum);
                        break;

                    case "OUT":
                        plate.Remove(plateNum);
                        break;
                    default:
                        break;
                }
            }
            if (plate.Count > 0)
            {
                foreach (var item in plate)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
