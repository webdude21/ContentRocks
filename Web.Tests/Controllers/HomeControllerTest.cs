namespace Web.Tests.Controllers
{
    using System.Linq;

    using Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Web.Controllers;
    using Web.Infrastructure.Cache;

    [TestClass]
    public class HomeControllerTest
    {
        public HomeController Controller { get; }

        public HomeControllerTest()
        {
            var dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
            var cacheService = new Mock<ICacheService>();
            cacheService.Setup(m => m.HomePosts).Returns(dataGenerator.GetPosts(3).ToList());
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute();
            this.Controller = new HomeController(cacheService.Object);
        }
    }
}