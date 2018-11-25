namespace ArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T item)
        {
            T[] items = new T[lenght];

            for (int i = 0; i < lenght; i++)
            {
                items[i] = item;
            }

            return items;
        }
    }
}