using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }
        public void Add(Book book)
        {
            books.Add(book);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.index = -1;
            }
            public Book Current => this.books[this.index];
            object IEnumerator.Current => Current;
            public void Dispose() { }

            bool IEnumerator.MoveNext()
            {
                index += 1;
                if (index < books.Count)
                {
                    return true;
                }
                return false;
            }

            void IEnumerator.Reset()
            {
                index = -1;
            }
        }
    }
}
