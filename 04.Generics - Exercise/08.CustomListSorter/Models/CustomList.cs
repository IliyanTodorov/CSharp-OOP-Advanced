namespace CustomListSorter.Models
{
    using Contracts;
    using System;
    using System.Linq;

    public class CustomList<T> : ICustomList<T>
        where T : IComparable<T>
    {
        private const int InitialCapacity = 4;

        private T[] array;

        public CustomList()
        {
            this.array = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            this.CheckArrayLength();

            this.array[this.Count++] = element;
        }

        public T Remove(int index)
        {
            T element = this.array[index];
            this.array[index] = default(T);
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            if (this.array.Length != this.Count)
            {
                this.array[this.Count] = default(T);
            }

            return element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int index1, int index2)
        {
            T tempVar = this.array[index1];

            this.array[index1] = this.array[index2];
            this.array[index2] = tempVar;
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            T maxItem = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(maxItem) > 0)
                {
                    maxItem = this.array[i];
                }
            }

            return maxItem;
        }

        public T Min()
        {
            T minItem = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(minItem) < 0)
                {
                    minItem = this.array[i];
                }
            }

            return minItem;
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i + 1; j < this.Count; j++)
                {
                    if (this.array[i].CompareTo(this.array[j]) > 0)
                    {
                        T tempVar = this.array[i];

                        this.array[i] = this.array[j];
                        this.array[j] = tempVar;
                    }
                }
            }
        }

        public override string ToString()
        {
            return string.Join("\n", this.array.Take(this.Count));
        }

        // PRIVATE
        private void CheckArrayLength()
        {
            if (this.array.Length == this.Count)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            T[] tempArray = new T[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                tempArray[i] = this.array[i];
            }

            this.array = tempArray;
        }
    }
}