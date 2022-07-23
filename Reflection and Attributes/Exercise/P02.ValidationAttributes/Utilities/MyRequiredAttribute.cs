namespace ValidationAttributes.Utilities
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
