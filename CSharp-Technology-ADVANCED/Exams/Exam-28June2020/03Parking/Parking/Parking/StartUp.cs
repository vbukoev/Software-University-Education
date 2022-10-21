using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            int datura = 0;
            int cherry = 0;
            int decoy = 0;
            int decrease = 0;
            while (true)
            {
                if (!effects.Any() || !casings.Any()) break;
                if (datura >= 3 && cherry >= 3 && decoy >= 3) break;
                int effect = effects.Peek();
                int casing = casings.Peek() - decrease;
                int sum = effect + casing;
                bool createdABomb = false;
                switch (sum)
                {
                    case 40:
                        datura++;
                        createdABomb = true;
                        break; 
                    case 60:
                        cherry++;
                        createdABomb = true;
                        break; 
                    case 120:
                        decoy++;
                        createdABomb = true;
                        break; 
                }
                if (createdABomb)
                {
                    effects.Dequeue();
                    casings.Pop();
                    decrease = 0;
                }
                else if (casing <= 0)
                {
                    casings.Pop();
                    decrease = 0;
                }
                else decrease = decrease + 5;
            }
            if (datura >= 3 && cherry >= 3 && decoy >= 3) Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            else Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            if (effects.Count==0) Console.WriteLine("Bomb Effects: empty");
            else Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            if (casings.Count==0) Console.WriteLine("Bomb Casings: empty");
            else Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {decoy}");
        }
    }
}
