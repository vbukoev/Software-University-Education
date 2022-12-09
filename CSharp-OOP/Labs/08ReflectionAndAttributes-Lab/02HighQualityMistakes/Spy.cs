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

            foreach (var field in nonPublicFields) result.AppendLine($"{field.Name} must be private!");

            foreach (var getter in nonPublicGetters) result.AppendLine($"{getter.Name} have to be public!");

            foreach (var setter in publicSetters) result.AppendLine($"{setter.Name} have to be private!");

            return result.ToString().TrimEnd();
        }   
    }
}