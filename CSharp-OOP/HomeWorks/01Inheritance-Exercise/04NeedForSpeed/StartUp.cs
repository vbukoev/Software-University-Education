using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            var car = new SportCar(200, 10);
            car.Drive(1);
            Console.WriteLine(car.Fuel);
        }
    }
}
