

using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car first = new Car();
            Car second = new Car(make, model, year);
            Car third = new Car(make, model, year, fuelQuantity, fuelConsumption);


        }
    }
}
