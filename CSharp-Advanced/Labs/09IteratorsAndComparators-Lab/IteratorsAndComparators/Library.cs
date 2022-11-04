using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;//
        public Library(params Book[] books)//
        {
            this.books = new List<Book>(books);
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
}
