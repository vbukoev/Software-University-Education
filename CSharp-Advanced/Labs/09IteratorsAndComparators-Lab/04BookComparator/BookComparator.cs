namespace IteratorsAndComparators

{
    using System.Text;
    using System;
    using System.Collections.Generic;

    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book first, Book sec)
        {
            int res = first.Title.CompareTo(sec.Title);
            if (res == 0)
            {
                return sec.Year.CompareTo(first.Year);
            }
            return res;
        }
    }
}
