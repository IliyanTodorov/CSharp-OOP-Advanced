namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public IReadOnlyList<Book> Books { get; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            private int currentIndex { get; set; }

            public bool MoveNext()
            {
                return ++currentIndex < this.books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}