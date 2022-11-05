﻿namespace BoxOfT
{
    using System;
    public class StartUp
    {
       public static void Main()
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());//we removed 3 
            box.Add(4);//and at the same time we added 6 because with the Remove() method we remove the topmost element
            box.Add(5);// we remove the last element added because this is a list of elements and we dont have ordering by the value
            Console.WriteLine(box.Remove());//of course we are going to remove the integer 5
        }
    }
}