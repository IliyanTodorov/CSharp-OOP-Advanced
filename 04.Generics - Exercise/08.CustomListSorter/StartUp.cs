namespace CustomListSorter
{
    using Contracts;
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            ICustomList<string> customList = new CustomList<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var token = input.Split();
                var command = token[0];

                string element = string.Empty;

                switch (command)
                {
                    case "Add":
                        element = token[1];
                        customList.Add(element);
                        break;
                    case "Remove":
                        var index = int.Parse(token[1]);
                        customList.Remove(index);
                        break;
                    case "Contains":
                        element = token[1];
                        Console.WriteLine(customList.Contains(element));
                        break;
                    case "Swap":
                        var index1 = int.Parse(token[1]);
                        var index2 = int.Parse(token[2]);
                        customList.Swap(index1, index2);
                        break;
                    case "Greater":
                        element = token[1];
                        Console.WriteLine(customList.CountGreaterThan(element));
                        break;
                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "Print":
                        Console.WriteLine(customList);
                        break;
                    case "Sort":
                        customList.Sort();
                        break;
                }
            }
        }
    }
}
