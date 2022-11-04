using System;

namespace P03.Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            double p1NumsCnt = 0;//Every diapason numbers count
            double p2NumsCnt = 0;//Double because we do not want integer division
            double p3NumsCnt = 0;//Percents are double 
            double p4NumsCnt = 0;
            double p5NumsCnt = 0;

            for (int i = 1; i <= n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                //Determine which is its diapason
                if (currNum < 200)
                {
                    p1NumsCnt++;
                }
                else if (currNum <= 399)
                {
                    p2NumsCnt++;
                }
                else if (currNum <= 599)
                {
                    p3NumsCnt++;
                }
                else if (currNum <= 799)
                {
                    p4NumsCnt++;
                }
                else
                {
                    p5NumsCnt++;
                }
            }
            double p1 = (p1NumsCnt / n) * 100;
            double p2 = (p2NumsCnt / n) * 100;
            double p3 = (p3NumsCnt / n) * 100;
            double p4 = (p4NumsCnt / n) * 100;
            double p5 = (p5NumsCnt / n) * 100;
            Console.WriteLine($"{p1:0.00}%");
            Console.WriteLine($"{p2:0.00}%");
            Console.WriteLine($"{p3:0.00}%");
            Console.WriteLine($"{p4:0.00}%");
            Console.WriteLine($"{p5:0.00}%");

            //int n = int.Parse(Console.ReadLine());
            //int[] arr = new int[n];
            //double p1Cnt = 0;//Every diapason numbers count
            //double p2Cnt = 0;//Double because we do not want integer division
            //double p3Cnt = 0;//Percents are double 
            //double p4Cnt = 0;
            //double p5Cnt = 0;

            //for (int i = 0; i < n; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //for (int i = 0; i < arr.Length; i++)

            //{
            //    if (arr[i] >= 1 && arr[i] < 200)
            //    {
            //        p1Cnt++;
            //    }
            //    else if (arr[i] >= 200 && arr[i] < 400)
            //    {
            //        p2Cnt++;
            //    }
            //    else if (arr[i] >= 400 && arr[i] < 600)
            //    {
            //        p3Cnt++;
            //    }
            //    else if (arr[i] >= 600 && arr[i] < 800)
            //    {
            //        p4Cnt++;
            //    }
            //    else
            //    {
            //        p5Cnt++;
            //    }
            //}
            //double p1 = (p1Cnt / n) * 100;
            //double p2 = (p2Cnt / n) * 100;
            //double p3 = (p3Cnt / n) * 100;
            //double p4 = (p4Cnt / n) * 100;
            //double p5 = (p5Cnt / n) * 100;
            //Console.WriteLine($"{p1:0.00}%");
            //Console.WriteLine($"{p2:0.00}%");
            //Console.WriteLine($"{p3:0.00}%");
            //Console.WriteLine($"{p4:0.00}%");
            //Console.WriteLine($"{p5:0.00}%");
        }
    }
}
