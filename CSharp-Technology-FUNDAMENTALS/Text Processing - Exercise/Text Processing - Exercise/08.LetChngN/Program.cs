using System;
using System.Linq;
using System.Text;

namespace _08.LetChngN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder digitAsNum = new StringBuilder();
            decimal totalSum = 0;
            var tokens = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < tokens.Count; i++)
            {
                string curToken = tokens[i];
                for (int j = 0; j < curToken.Length; j++)
                {
                    char currSym = curToken[j];
                    if (char.IsDigit(currSym)) digitAsNum.Append(currSym);
                }
                decimal num = decimal.Parse(digitAsNum.ToString());
                for (int j = 0; j < curToken.Length; j++)
                {
                    char curSym = curToken[j];
                    if (char.IsLetter(curSym)&& char.IsUpper(curSym))
                    {
                        int position = curSym - 65 + 1; //-> (curSym-64) <-
                        num = num / position;
                        break;
                    }
                    else if (char.IsLetter(curSym) && char.IsLower(curSym))
                    {
                        int position = curSym - 97 + 1;//-> (curSym-96) <-
                        num = num * position;
                        break;
                    }
                }
                int lastIndex = curToken.LastIndexOf(digitAsNum.ToString());
                for (int j = lastIndex; j < curToken.Length; j++)
                {
                    char curSym = curToken[j];
                    if (char.IsLetter(curSym) && char.IsUpper(curSym))
                    {
                        int position = curSym - 65 + 1;
                        num = num - position;
                        break;
                    }
                    else if (char.IsLetter(curSym) && char.IsLower(curSym))
                    {
                        int position = curSym - 97 + 1;
                        num = num + position;
                        break;
                    }
                }
                totalSum = totalSum + num;
                digitAsNum.Clear();
            }
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
