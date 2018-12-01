using System;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (var methodInfo in methods)
        {
            var customAttribute = methodInfo.GetCustomAttribute<SoftUniAttribute>();

            if (customAttribute != null)
            {
                Console.WriteLine($"{methodInfo.Name} is written by {customAttribute.Name}");
            }
        }
    }
}
