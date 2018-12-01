using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        var type = Type.GetType(className);

        var allMethods = type
            .GetMethods(BindingFlags.Public |
                        BindingFlags.Instance |
                        BindingFlags.NonPublic);

        foreach (var method in allMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in allMethods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }
        
        return sb.ToString().Trim();
    }
}
