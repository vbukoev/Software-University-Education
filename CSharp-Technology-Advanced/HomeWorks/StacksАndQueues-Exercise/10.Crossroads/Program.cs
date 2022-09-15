using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightSec = int.Parse(Console.ReadLine());
            int freeWindowSec = int.Parse(Console.ReadLine());

            var carQueue = new Queue<string>();
            int passedCarCnt = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") break;
                if (input == "green")
                {
                    int greenLight = greenLightSec;
                    int freeWindow = freeWindowSec;
                    while (carQueue.Any())
                    {
                        string currCar = carQueue.Peek();
                        if (greenLight >= currCar.Length)
                        {
                            greenLight -= currCar.Length;
                            carQueue.Dequeue();
                            passedCarCnt++;
                        }
                        else if (greenLight <= 0) break;
                        else if (greenLight < currCar.Length)
                        {
                            if (greenLight + freeWindow >= currCar.Length)
                            {
                                greenLight = 0;
                                freeWindow -= currCar.Length;
                                carQueue.Dequeue();
                                passedCarCnt++;
                            }
                            else
                            {
                                int crashIndex = greenLight + freeWindow;
                                if (crashIndex >= 0 && crashIndex < currCar.Length)
                                {
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currCar} was hit at {currCar[crashIndex]}.");
                                    return;
                                }
                            }
                        }

                    }
                }
                else
                {
                    carQueue.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarCnt} total cars passed the crossroads.");
        }
    }
}
