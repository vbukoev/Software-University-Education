namespace Stealer
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type classType = Type.GetType(className);

            IEnumerable<FieldInfo> fields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => fieldNames.Contains(x.Name));

            object classInstance = Activator.CreateInstance(classType);

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fields)
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return result.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] nonPublicFields = classType.
                GetFields(BindingFlags.Instance | BindingFlags.Public);

            IEnumerable<MethodInfo> nonPublicGetters = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.Name.StartsWith("get"));

            IEnumerable<MethodInfo> publicSetters = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.Name.StartsWith("set"));

            StringBuilder result = new StringBuilder();

            foreach (FieldInfo field in nonPublicFields) result.AppendLine($"{field.Name} must be private!");

            foreach (MethodInfo getter in nonPublicGetters) result.AppendLine($"{getter.Name} have to be public!");

            foreach (MethodInfo setter in publicSetters) result.AppendLine($"{setter.Name} have to be private!");

            return result.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] privateMethods = classType.
                GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder result = new StringBuilder();

            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in privateMethods) result.AppendLine($"{method.Name}");

            return result.ToString().TrimEnd();
        }

        public string Collector(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] methods =
                classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder result = new StringBuilder();

            foreach (MethodInfo method in methods.Where(x=>x.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(x=>x.Name.StartsWith("set"))) //setter collector
            {
                Type parameterType = method.GetParameters().FirstOrDefault().ParameterType;

                result.AppendLine($"{method.Name} will set field of {parameterType}");

            }
            return result.ToString().TrimEnd();
        }
    }
}