namespace GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class Box<T> where T : IComparable
    {
        public Box(IList<T> items)
        {
            this.Items = items;
        }

        public IList<T> Items { get; private set; }

        public int GreaterElements(T element)
        {
            int counter = 0;

            foreach (var item in this.Items)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}