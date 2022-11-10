namespace _08CollectionHierarchy.Core
{
    using _08CollectionHierarchy.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        private readonly IAddCollection addCollection;
        private readonly IAddRemoveCollection addRemoveCollection;
        private readonly IMyList myList;
        public Engine(IAddCollection addCollection, IAddRemoveCollection addRemoveCollection, IMyList myList)
        {
            this.addCollection = addCollection;
            this.addRemoveCollection = addRemoveCollection;
            this.myList = myList;
        }
        public void Run()
        {
            var input = Console.ReadLine().Split();
            var removeOperationsCount = int.Parse(Console.ReadLine());
            PrintResults(input, removeOperationsCount);
        }

        private void PrintResults(string[] input, int removeOperationsCount)
        {
            PrintAddedResults(input, this.addCollection);
            PrintAddedResults(input, this.addRemoveCollection);
            PrintAddedResults(input, this.myList);

            PrintRemovedResults(removeOperationsCount, this.addRemoveCollection);
            PrintRemovedResults(removeOperationsCount, this.myList);
        }

        private void PrintAddedResults(string[] input, IAddCollection collection)
        {
            var addedResult = new List<int>();
            foreach (var item in input)
            {
                addedResult.Add(collection.Add(item));
            }
            Console.WriteLine(string.Join(" ", addedResult));
        }
        private void PrintRemovedResults(int removeOperationsCount, IAddRemoveCollection collection)
        {
            var removedResult = new List<string>();
            for (int i = 0; i < removeOperationsCount; i++)
            {
                removedResult.Add(collection.Remove());
            }
            Console.WriteLine(string.Join(" ", removedResult));
        }
    }
}