namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);

            var box = (BlackBoxInteger)Activator.CreateInstance(type, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var token = input.Split("_");

                var command = token[0];
                var value = int.Parse(token[1]);

                var method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(m => m.Name == command);

                if (method != null) method.Invoke(box, new object[] {value});

                var result = type
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(f => f.Name == "innerValue")
                    ?.GetValue(box);

                Console.WriteLine(result);
            }
        }
    }
}
