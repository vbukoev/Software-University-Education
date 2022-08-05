using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phones = Console.ReadLine();
            var regex = @"\+359([ -])2\1\d{3}\1\d{4}\b";            
            var phoneMatch = Regex.Matches(phones, regex);
            var matched = phoneMatch.Cast<Match>().Select(a => a.Value.Trim()).ToArray();
            Console.WriteLine(String.Join(", ", matched));
        }
    }
}
