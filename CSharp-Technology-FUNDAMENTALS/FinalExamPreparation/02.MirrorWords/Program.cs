using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mirrorWords = new Dictionary<string, string>();
            var input = Console.ReadLine();
            Regex pattern = new Regex(@"(?<getAllValidCharsBeforeTheWord>([@#]))(?<getTheWordWithAtLeast3CharsInIt>([A-Za-z]{3,}))\1{2}(?<getsTheReversedWordWithAtLeast3CharsInIt>([A-Za-z]){3,})\1");
            MatchCollection matches = pattern.Matches(input);
            if (matches.Count > 0) Console.WriteLine($"{matches.Count} word pairs found!"); //Checks if there are matches and prints their cnt
            else Console.WriteLine("No word pairs found!");
            foreach (Match match in matches)
            {
                var word = match.Groups["getTheWordWithAtLeast3CharsInIt"].Value;
                var mirror = match.Groups["getsTheReversedWordWithAtLeast3CharsInIt"].Value;
                var reverse = mirror;
                var reverseMirror = reverse.ToCharArray();
                Array.Reverse(reverseMirror);
                var mirrorWord = new string(reverseMirror);
                if (word == mirrorWord) mirrorWords.Add(word, mirror);
            }
            if (mirrorWords.Count == 0) Console.WriteLine("No mirror words!");
            else
            {
                var cnt = 1;
                Console.WriteLine("The mirror words are:");
                foreach (var word in mirrorWords)
                {                    
                    if (cnt == mirrorWords.Count) Console.Write($"{word.Key} <=> {word.Value}");
                    else Console.Write($"{word.Key} <=> {word.Value}, ");
                    cnt++;
                }
            }
        }
    }
}