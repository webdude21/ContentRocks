namespace Services.Contracts
{
    using System.Linq;

    using Models.Identity;

    public interface IAuthorService : IService
    {
        void DeleteBy(string id);

        IQueryable<ApplicationUser> GetAll();

        ApplicationUser GetBy(string username);
    }
}