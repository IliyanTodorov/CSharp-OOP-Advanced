namespace GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var items = new List<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Double.Parse(Console.ReadLine());

                items.Add(input);
            }

            var element = Double.Parse(Console.ReadLine());

            var box = new Box<double>(items);

            Console.WriteLine(box.GreaterElements(element));
        }
    }
}
