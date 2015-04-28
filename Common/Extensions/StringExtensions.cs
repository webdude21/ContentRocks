namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static string TrimWithEllipsis(this string value, int stringLength)
        {
            return value.Substring(0, stringLength) + "...";
        }
    }
}