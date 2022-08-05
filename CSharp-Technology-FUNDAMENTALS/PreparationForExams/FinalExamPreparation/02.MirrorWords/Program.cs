using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mirrorWords = new Dictionary<string, string>(); // dictionary 
            var input = Console.ReadLine(); //input from the console
            Regex pattern = new Regex(@"(?<getAllValidCharsBeforeTheWord>([@#]))(?<getTheWordWithAtLeast3CharsInIt>([A-Za-z]{3,}))\1{2}(?<getsTheReversedWordWithAtLeast3CharsInIt>([A-Za-z]){3,})\1"); //the regex pattern
            MatchCollection matches = pattern.Matches(input); // matchCollection
            if (matches.Count > 0) Console.WriteLine($"{matches.Count} word pairs found!"); //Checks if there are matches and prints their cnt
            else Console.WriteLine("No word pairs found!"); // prints on the console there aren't any pairs
            foreach (Match match in matches)
            {
                var word = match.Groups["getTheWordWithAtLeast3CharsInIt"].Value; // gets the value from the group where the word is 
                var mirror = match.Groups["getsTheReversedWordWithAtLeast3CharsInIt"].Value; // gets the value from the group where the reversed word is
                var reverse = mirror; // string reverse gets the reversed word and then it is going to be a char Array
                var reverseMirror = reverse.ToCharArray(); // the char array
                Array.Reverse(reverseMirror); // reversing the char array 
                var mirrorWord = new string(reverseMirror); // "mirrorWord" gets the value from the charArr and it gets it as a string 
                if (word == mirrorWord) mirrorWords.Add(word, mirror);// checks if the word is equal to the value of the mirrorWord and if it is we add it to the Dictionary 
            }
            if (mirrorWords.Count == 0) Console.WriteLine("No mirror words!"); // checks if there are mirrorWords and if there aren't we print on the console that there are no mirror words
            else
            {
                var cnt = 1; // int count which is equal to 1 so that we don't have to increment the count rigth in the begining of the foreach loop
                Console.WriteLine("The mirror words are:");
                foreach (var word in mirrorWords) 
                {                    
                    if (cnt == mirrorWords.Count) Console.Write($"{word.Key} <=> {word.Value}"); // checks if the count is equal to the Dictionary count and if it is it prints the word Key with its value
                    else Console.Write($"{word.Key} <=> {word.Value}, "); //if it is not it prints the mirrorWords  
                    cnt++; //count increments by 1
                }
            }
        }
    }
}