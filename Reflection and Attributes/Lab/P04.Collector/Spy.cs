﻿namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] fields)
        {
            Type classType = Type.GetType(nameOfClass);
            FieldInfo[] fieldInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Public |
                                                        BindingFlags.NonPublic | BindingFlags.Static);

            object classInstance = Activator.CreateInstance(classType);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (FieldInfo field in fieldInfo.Where(f => fields.Any(fp => fp.Contains(f.Name))))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type classType = assembly.GetTypes().FirstOrDefault(t => t.Name == className);

            FieldInfo[] fieldInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] publicInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in fieldInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in nonPublicInfo.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in publicInfo.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"All Private Methods of Class: {className}");

            Type classType = Type.GetType(className);

            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] nonPublic = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            foreach (MethodInfo method in nonPublic)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            foreach (var method in methods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
