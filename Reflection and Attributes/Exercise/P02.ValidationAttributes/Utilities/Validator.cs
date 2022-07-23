namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties().Where(p=>p.CustomAttributes.Any(a=>a.AttributeType.BaseType == typeof(MyValidationAttribute))).ToArray();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);

                foreach (var customAttributeData in property.CustomAttributes)
                {
                    Type typeProp = customAttributeData.AttributeType;

                    object instance = property.GetCustomAttribute(typeProp);

                    MethodInfo method = typeProp.GetMethod("IsValid");
                    bool result = (bool)method.Invoke(instance, new object[] { propValue });

                    if (!result) return false;
                }
                
            }
            
            return true;
        }
    }
}
