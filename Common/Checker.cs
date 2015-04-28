namespace Common
{
    using System;

    public static class Checker
    {
        public static void CheckForNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name, string.Format("{0} should not be null", name));
            }
        }

        public static int GetValidPageNumber(int? page)
        {
            var actualPage = 1;

            if (page.HasValue && page.Value > 1)
            {
                actualPage = page.Value;
            }
            return actualPage;
        }
    }
}