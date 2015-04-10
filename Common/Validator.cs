namespace Common
{
    using System;

    public static class Validator
    {
        public static void CheckForNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name, string.Format("{0} should not be null", name));
            }
        }
    }
}