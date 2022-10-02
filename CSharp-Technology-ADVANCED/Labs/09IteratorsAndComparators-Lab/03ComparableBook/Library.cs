namespace IteratorsAndComparators
{
using System.Text; 
using System;
using System.Collections;
using System.Collections.Generic;
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;//
        public Library(params Book[] books)//
        {
            this.books = new SortedSet<Book>(books);
        }
        public void Add(Book book)//
        {
            books.Add(book);
        }
        public IEnumerator<Book> GetEnumerator()//
        {
            foreach (var item in books)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}

