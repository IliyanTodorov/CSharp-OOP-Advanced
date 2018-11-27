namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IReadOnlyList<Book> Books => books.AsReadOnly();

        public void Sort()
        {
            this.books.Sort();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return this.Books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}