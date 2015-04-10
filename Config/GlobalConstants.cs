namespace Config
{
    public static class GlobalConstants
    {
        public static readonly int PageSize = ApplicationSettings.Default.PageSize;

        public static readonly string ConnectionString = ApplicationSettings.Default.ConnectionName;
    }
}