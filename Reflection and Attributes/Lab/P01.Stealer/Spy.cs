namespace Stealer
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
    }
}
