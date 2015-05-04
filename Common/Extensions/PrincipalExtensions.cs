namespace Common.Extensions
{
    using System.Security.Principal;

    using Config;

    public static class PrincipalExtensions
    {
        public static bool IsAdmin(this IPrincipal principal)
        {
            return principal.IsInRole(GlobalConstants.AdministratorRoleName);
        }

        public static bool IsLoggedIn(this IPrincipal principal)
        {
            return principal.Identity.IsAuthenticated;
        }
    }
}