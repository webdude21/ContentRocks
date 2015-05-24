namespace Web.Tests.Controllers
{
    using System.Web;
    using System.Web.Caching;

    using Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Services.Contracts;

    using Web.Controllers;

    [TestClass]
    public class HomeControllerTest
    {
        private readonly HomeController controller;

        public HomeControllerTest()
        {
            var dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Cache).Returns(new Cache());
            var postService = new Mock<IPostService>();
            postService.Setup(m => m.GetTheLatestPosts()).Returns(dataGenerator.GetPosts(3));
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute();
            this.controller = new HomeController(postService.Object);
        }
    }
}