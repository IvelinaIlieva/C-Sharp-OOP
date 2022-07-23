namespace ValidationAttributes.Utilities
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
