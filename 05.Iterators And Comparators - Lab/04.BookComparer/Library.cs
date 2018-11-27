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

        public void Sort()
        {
            this.books.Sort(new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            this.books.Sort(new BookComparator());
            return this.books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}