namespace GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public Box(IList<T> items)
        {
            this.Items = items;
        }

        public IList<T> Items { get; private set; }

        public void SwapIntegers(int firstIndex, int secondIndex)
        {
            if (this.Items.Count <= firstIndex) throw new ArgumentException("Invalid first index");

            if (this.Items.Count <= secondIndex) throw new ArgumentException("Invalid second index");

            T firstElement = this.Items[firstIndex];
            T secondElement = this.Items[secondIndex];

            this.Items[firstIndex] = secondElement;
            this.Items[secondIndex] = firstElement;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                var fullname = item.GetType().FullName + ": ";
                var content = fullname + item;

                sb.Append(content);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}