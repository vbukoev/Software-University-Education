using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace CustomStructure
{
    public class CustomList
    {
        private const int defaultSize = 2;
        private int[] elements;
        public int Count { get; private set; }
        public CustomList()
        {
            this.Count = 0;
            this.elements = new int[defaultSize];
        }
        public CustomList(int initialSize) : this()
        {
            this.elements = new int[initialSize];
        }
        public int this[int index]//-> adding the INDEXER with an "index"
        {
            get
            {
                CheckIndexOutOfRange(index);
                return this.elements[index];
            }
            set
            {
                CheckIndexOutOfRange(index);//checks if the index is in the correct range
                this.elements[index] = value;

            }
        }
        public void Add(int element)
        {
            if (this.elements.Length == this.Count)
            {
                Resize();
            }
            this.elements[this.Count] = element;
            this.Count++;
        }
        public int RemoveAt(int index)
        {
            var element = elements[index];//the variable which is going to be removed and which is going to be returned at the end
            CheckIndexOutOfRange(index);//checks if the index is valid

            Shift(index);//shift the index to the left side
            this.Count--;//count will going to be decreased by 1
            if (Count < elements.Length / 4)
            {
                Shrink();
            }

            return element;
        }
        public void Insert(int index, int element)
        {
            CheckIndexOutOfRange(index);
            ShiftToRight(index);
            elements[index] = element;
            Count++;
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (elements[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstElement, int secondElement)
        {
            CheckIndexOutOfRange(firstElement);//checks the index of the first element if it is in the range
            CheckIndexOutOfRange(secondElement);//checks the index of the second element if it is in the range
            int temp = elements[firstElement];
            elements[firstElement] = elements[secondElement];
            elements[secondElement] = temp;
        }
        //private methods
        private void ShiftToRight(int index)
        {
            if (elements.Length == Count) //checks if there is a need of resizing the elements int array
            {
                Resize();
            }
            for (int i = Count - 1; i >= index; i--)
            {
                elements[i + 1] = elements[i];
            }
            elements[index] = default;
        }
        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
        }
        private void Shrink()
        {
            var copy = new int[this.elements.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = elements[i];
            }
            elements = copy;
        }
        private void CheckIndexOutOfRange(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private void Resize()
        {
            Resize(this.elements.Length * 2);
        }
        private void Resize(int newSize)
        {
            var newValues = new int[newSize];
            for (int i = 0; i < elements.Length; i++)
            {
                newValues[i] = this.elements[i];
            }
            this.elements = newValues;
        }
    }
}
