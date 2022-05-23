using System;

namespace _10.Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCnt = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double headsetCost = (lostGamesCnt / 2) * headsetPrice;
            double miceCost = (lostGamesCnt / 3) * mousePrice;
            double keyboardSetCost = (lostGamesCnt / 6) * keyboardPrice;
            double displaySetCost = (lostGamesCnt / 12) * displayPrice;
            double totalPrice = headsetCost + miceCost + keyboardSetCost + displaySetCost;

            //Every second lost game, Petar trashes his headset.
            //Every third lost game, Petar trashes his mouse.
            //When Petar trashes both his mouse and headset in the same lost game, he also trashes his keyboard.
            //Every second time, when he trashes his keyboard, he also trashes his display.
            
            Console.WriteLine($"Rage expenses: {totalPrice:F2} lv.");
        }
    }
}