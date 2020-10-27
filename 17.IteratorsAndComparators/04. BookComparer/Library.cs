﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            Books = new SortedSet<Book>(books, new BookComparator()); // тук викаме новия компаратор
        }
        public SortedSet<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(Books.ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int index = -1;
            public LibraryIterator(List<Book> books)
            {
                Books = books;
            }

            public List<Book> Books { get; set; }
            public Book Current => Books[index];

            object IEnumerator.Current => Books[index];

            public void Dispose() {}

            public bool MoveNext()
            {
                return  ++index<Books.Count; //докато увеличаваме index и той е < Count връща True, сначе връща False
            }

            public void Reset()
            {
                index = -1; ;
            }
        }
    }
}
