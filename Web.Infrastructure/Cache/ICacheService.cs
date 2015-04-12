namespace Web.Infrastructure.Cache
{
    using System.Collections.Generic;

    public interface ICacheService
    {
        IList<string> Countries { get; }
    }
}
