namespace GenericBoxOfInteger
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                var box = new Box<Int32>(input);
                Console.WriteLine(box);
            }
        }
    }
}
