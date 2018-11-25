namespace GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var items = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                items.Add(input);
            }

            var element = Console.ReadLine();

            var box = new Box<string>(items);

            Console.WriteLine(box.GreaterElements(element));
        }
    }
}
