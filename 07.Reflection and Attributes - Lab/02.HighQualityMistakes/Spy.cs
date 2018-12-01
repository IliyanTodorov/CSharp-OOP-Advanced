using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        var type = Type.GetType(className);

        var publicFields = type.GetFields().Where(x => x.IsPublic);
        
        var privateMethods = type
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name.StartsWith("get"));
        var publicMethods = type
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.Name.StartsWith("set"));

        foreach (var fieldInfo in publicFields)
        {
            sb.AppendLine($"{fieldInfo.Name} must be private!");
        }

        foreach (var privateMethod in privateMethods)
        {
            sb.AppendLine($"{privateMethod.Name} have to be public!");
        }

        foreach (var publicMethod in publicMethods)
        {
            sb.AppendLine($"{publicMethod.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }
}
