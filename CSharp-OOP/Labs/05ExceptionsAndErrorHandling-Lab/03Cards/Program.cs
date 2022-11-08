using System.Collections.Generic;
using System.Linq;

namespace _03Cards
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            string[] input = Console.ReadLine().Split(", ");
            for (int i = 0; i < input.Length; i++)
            {
                string face = input[i].Split().First();
                string suit = input[i].Split().Last();
                try
                {
                    cards.Add(CardCreation(face, suit));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine(string.Join(" ", cards));
        }

        private static Card CardCreation(string face, string suit)
        {
            string[] validFace = new string[]
                { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuits = new string[] { "S", "H", "D", "C" };
            if (!validFace.Contains(face) || !validSuits.Contains(suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            string utf = "";
            if (suit == "S") utf = "\u2660";
            else if (suit == "H") utf = "\u2665";
            else if (suit == "D") utf = "\u2666";
            else if (suit == "C") utf = "\u2663";
            return new Card(face, utf);
        }
    }

    public class Card
    {
        public string Face { get; set; }
        public string Suit { get; set; }

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
