using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (string author, string key)> pieces = new Dictionary<string, (string author, string key)>();
            int numberOfLoops = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLoops; i++)
            {
                var input = Console.ReadLine().Split("|");
                var piece = input[0];
                var compose = input[1];
                var key = input[2];
                pieces.Add(piece, (compose, key));
            }
            string cmd = Console.ReadLine();
            while (true)
            {
                if (cmd == "Stop") break;
                var command = cmd.Split("|");
                var action = command[0];
                var piece = command[1];
                switch (action)
                {
                    case "Add":
                        string composer = command[2];
                        string key = command[3];
                        if (!pieces.ContainsKey(piece))
                        {
                            pieces.Add(piece, (composer, key));
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        else Console.WriteLine($"{piece} is already in the collection!");
                        break;

                    case "Remove":
                        if (pieces.ContainsKey(piece))
                        {
                            pieces.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;

                    case "ChangeKey":
                        key = command[2];
                        if (pieces.ContainsKey(piece))
                        {
                            pieces[piece] = (pieces[piece].author, key);
                            Console.WriteLine($"Changed the key of {piece} to {pieces[piece].key}!");
                        }
                        else Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;
                }
                cmd = Console.ReadLine();
            }
            foreach (var item in pieces)
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.author}, Key: {item.Value.key}");
        }
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//using System;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Collections.Generic;
//using System.Numerics;
//using System.Linq;

//namespace Piano
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Dictionary<string, (string author, string key)> pieces = new Dictionary<string, (string author, string key)>();
//            int n = int.Parse(Console.ReadLine());

//            for (int i = 0; i < n; i++)
//            {
//                string[] input = Console.ReadLine().Split("|");
//                string sonata = input[0];
//                string compose = input[1];
//                string key = input[2];

//                pieces.Add(sonata, (compose, key));
//            }

//            string command = Console.ReadLine();

//            while (command != "Stop")
//            {
//                string[] cmd = command.Split("|");
//                string action = cmd[0];
//                string sonata = cmd[1];

//                if (action == "Add")
//                {
//                    string composer = cmd[2];
//                    string key = cmd[3];

//                    if (!pieces.ContainsKey(sonata))
//                    {
//                        pieces.Add(sonata, (composer, key));
//                        Console.WriteLine($"{sonata} by {composer} in {key} added to the collection!");
//                    }
//                    else
//                    {
//                        Console.WriteLine($"{sonata} is already in the collection!");
//                    }
//                }
//                else if (action == "Remove")
//                {
//                    if (pieces.ContainsKey(sonata))
//                    {
//                        pieces.Remove(sonata);
//                        Console.WriteLine($"Successfully removed {sonata}!");
//                    }
//                    else
//                    {
//                        Console.WriteLine($"Invalid operation! {sonata} does not exist in the collection.");
//                    }
//                }
//                else if (action == "ChangeKey")
//                {
//                    string key = cmd[2];

//                    if (pieces.ContainsKey(sonata))
//                    {
//                        pieces[sonata] = (pieces[sonata].author, key);
//                        Console.WriteLine($"Changed the key of {sonata} to {pieces[sonata].key}!");
//                    }
//                    else
//                    {
//                        Console.WriteLine($"Invalid operation! {sonata} does not exist in the collection.");
//                    }
//                }

//                command = Console.ReadLine();
//            }
//            var orderedPieces = pieces
//                .OrderBy(x => x.Key)
//                .ThenBy(x => x.Value[1]);

//            foreach (var kvp in orderedPieces) Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value[0]}, Key: {kvp.Value[1]}");

//        }
//    }
//}
