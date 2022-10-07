using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] array = new T[length];// sets the length of the array
            for (int i = 0; i < length; i++) // loops through every index of the created array and adds the item
            {
                array[i] = item;
            }
            return array; // at the end of the method we have created an array with the elements in it
        }
    }
}
