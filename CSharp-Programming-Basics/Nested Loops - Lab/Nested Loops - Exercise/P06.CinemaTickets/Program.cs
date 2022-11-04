using System;

namespace P06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string movie = Console.ReadLine();
            //byte numStudent = 0;
            //byte numStandard = 0;
            //byte numKid = 0;
            //while (movie != "Finish")
            //{
            //    byte seats = byte.Parse(Console.ReadLine());
            //    byte movieTickets = 0;
            //    for (int i = 0; i < seats; i++)
            //    {
            //        string seatType = Console.ReadLine();
            //        if (seatType == "End")
            //        {
            //            break;
            //        }
            //        else if (seatType == "student")
            //        {
            //            numStudent++;
            //        }
            //        else if (seatType == "standard")
            //        {
            //            numStandard++;
            //        }
            //        else if (seatType == "kid")
            //        {
            //            numKid++;
            //        }
            //        movieTickets++;
            //    }
            //    Console.WriteLine($"{movie} - {(float)movieTickets / seats * 100:f2}% full.");
            //    movie = Console.ReadLine();
            //}
            //int totalTickets = numStudent + numStandard + numKid;
            //string output = string.Format($"Total tickets: {totalTickets}\n" +
            //    $"{(float)numStudent / totalTickets * 100f:f2}% student tickets.\n" +
            //    $"{(float)numStandard / totalTickets * 100f:f2}% standard tickets.\n" +
            //    $"{(float)numKid / totalTickets * 100f:f2}% kids tickets.");
            //Console.WriteLine(output);




            string nameOfMovie = Console.ReadLine();
            int numKid = 0;
            int numStudent = 0;
            int numStandard = 0;
            while (nameOfMovie != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                int ticketCnt = 0;
                for (int i = 0; i < freeSeats; i++)
                {
                    string typeOfTheBoughtTicket = Console.ReadLine();

                    if (typeOfTheBoughtTicket == "End")
                    {
                        break;
                    }
                    else if (typeOfTheBoughtTicket == "student")
                    {
                        numStudent++;
                    }
                    else if (typeOfTheBoughtTicket == "kid")
                    {
                        numKid++;
                    }
                    else if (typeOfTheBoughtTicket == "standard")
                    {
                        numStandard++;
                    }
                    ticketCnt++;
                }
                Console.WriteLine($"{nameOfMovie} - {(double)ticketCnt / freeSeats * 100:f2}% full.");
                nameOfMovie = Console.ReadLine();
            }
            int totalTickets = numStandard + numKid + numStudent;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(double)numStudent / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{(double)numStandard / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{(double)numKid / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
