using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();

        var type = Type.GetType(className);

        var privateMethods = type
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var privateMethod in privateMethods)
        {
            sb.AppendLine($"{privateMethod.Name}");
        }

        return sb.ToString().Trim();
    }
}
