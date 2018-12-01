using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] inputFields)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        var type = Type.GetType(className);

        var hackerInstance = Activator.CreateInstance(type);

        foreach (var field in inputFields)
        {
            var currentField = type.GetField(field, (BindingFlags)62);

            var value = currentField.GetValue(hackerInstance);

            sb.AppendLine($"{currentField.Name} = {value}");
        }

        return sb.ToString().TrimEnd();
    }
}