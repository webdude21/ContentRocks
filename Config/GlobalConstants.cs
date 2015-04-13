namespace Config
{
    public static class GlobalConstants
    {
        public const string AdministratorRoleName = "Admin";

        public static readonly string ConnectionString = ApplicationSettings.Default.ConnectionName;

        public static readonly int PageSize = ApplicationSettings.Default.PageSize;
    }
}