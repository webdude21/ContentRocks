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
        private readonly HomeController controller;

        public HomeControllerTest()
        {
            var dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
            var cacheService = new Mock<ICacheService>();
            cacheService.Setup(m => m.HomePosts).Returns(dataGenerator.GetPosts(3).ToList());
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute();
            this.controller = new HomeController(cacheService.Object);
        }
    }
}