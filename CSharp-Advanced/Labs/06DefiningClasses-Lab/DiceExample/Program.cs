using System;
using System.Collections.Generic;

namespace DiceExample
{
    public class Program
    {
        
        static void Main(string[] args)
        {            
            List<Dice> dices = new List<Dice>(); //adds the dices side which were thrown
            while (true)
            {
                Console.Beep();
                Console.ReadLine();
                Dice dice = ThrowDice();
                dices.Add(dice);
                Console.WriteLine($"Dice: {dice.Side}");
            }
        }
        static Dice ThrowDice()
        {
            Random random = new Random();
            int side = random.Next(1, 7);
            Dice dice = new Dice() { Side = side, Color = "pink"}; //Side is a prop, Color is also a prop
            return dice; 
        }
    }
}
