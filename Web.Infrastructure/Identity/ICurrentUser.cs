namespace Web.Infrastructure.Identity
{
    using Models.Identity;

    public interface ICurrentUser
    {
        ApplicationUser Get();
    }
}