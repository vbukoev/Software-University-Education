using System;
using System.Linq;

namespace _07Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split().ToArray();
            var name = $"{data[0]} {data[1]}";
            var adress = data[2];
            var info = new Tuple<string, string>(name, adress);
            Console.WriteLine(info);

            var beerData = Console.ReadLine().Split().ToArray();
            var beerName = beerData[0];
            var littersBeer = int.Parse(beerData[1]);
            var beerInfo = new Tuple<string, int>(beerName, littersBeer);
            Console.WriteLine(beerInfo);
            
            var line = Console.ReadLine().Split().ToArray();
            var firstLine = int.Parse(line[0]);
            var secLine = double.Parse(line[1]);
            var tuple = new Tuple<int, double>(firstLine, secLine);
            Console.WriteLine(tuple);

        }
    }
}
