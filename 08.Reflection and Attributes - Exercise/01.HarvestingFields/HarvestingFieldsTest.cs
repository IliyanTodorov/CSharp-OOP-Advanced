namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);

            var fields = type
                .GetFields((BindingFlags)62);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                if (command != "all")
                {
                    var fieldsToPrint = fields
                        .Where(
                            x => x
                                .Attributes
                                .ToString()
                                .ToLower()
                                .Replace("family", "protected") 
                                 == command)
                         .ToArray();

                    foreach (var fieldInfo in fieldsToPrint)
                    {
                        var accessModifier = fieldInfo
                            .Attributes
                            .ToString()
                            .ToLower()
                            .Replace("family", "protected");

                        Console.WriteLine($"{accessModifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    }
                }
                else
                {
                    foreach (var fieldInfo in fields)
                    {
                        var accessModifier = fieldInfo
                            .Attributes
                            .ToString()
                            .ToLower()
                            .Replace("family", "protected");

                        Console.WriteLine($"{accessModifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    }
                }
            }
        }
    }
}
