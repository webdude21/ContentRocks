namespace Web.Tests.Controllers
{
    using System.Collections.Generic;

    using Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Services.Contracts;

    using TestStack.FluentMVCTesting;

    using Web.Controllers;
    using Web.ViewModels.Content;

    [TestClass]
    public class HomeControllerTest
    {
        private readonly HomeController controller;

        public HomeControllerTest()
        {
            var dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
            var postService = new Mock<IPostService>();
            postService.Setup(m => m.GetTheLatestPosts()).Returns(dataGenerator.GetPosts(3));
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute();
            this.controller = new HomeController(postService.Object);
        }

        [TestMethod]
        public void About()
        {
            this.controller.WithCallTo(c => c.About()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Contact()
        {
            this.controller.WithCallTo(c => c.Contact()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Index()
        {
            this.controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView().WithModel<List<PostViewModel>>();
        }
    }
}