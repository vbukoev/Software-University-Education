using System;
using System.Numerics;
using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string reallyBigNum = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            if (num == 0) 
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb= new StringBuilder();
            int remain = 0;

            for (int i = reallyBigNum.Length - 1; i >= 0 ; i--)
            {
                char lastNum = reallyBigNum[i];
                int lastNumAsDigit = int.Parse(lastNum.ToString());
                int res = lastNumAsDigit * num + remain;
                sb.Append(res % 10);
                remain = res / 10;
            }
            
            if (remain!=0) sb.Append(remain);
            
            StringBuilder reversed = new StringBuilder();
            
            for (int i = sb.Length - 1; i >= 0; i--) reversed.Append(sb[i]);
            
            Console.WriteLine(reversed);

            //vv Another WAY To Solve The Task vv  

                //BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
                //int secondNum = int.Parse(Console.ReadLine());
                //BigInteger res = firstNum * secondNum;
                //Console.WriteLine(res);
        }
    }
}
