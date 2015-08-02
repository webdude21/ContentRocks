namespace Web.Tests.Controllers
{
    using System.Collections.Generic;

    using Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Services.Contracts;

    using TestStack.FluentMVCTesting;

    using Web.Controllers;
    using Infrastructure;
    using ViewModels.Content;

    [TestClass]
    public class PostsControllerTest
    {
        private readonly PostsController controller;

        public PostsControllerTest()
        {
            var dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
            var postService = new Mock<IPostService>();
            var imageUploader = new Mock<IFileUploader>();
            postService.Setup(m => m.GetTheLatestPosts()).Returns(dataGenerator.GetPosts(20));
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute();
            this.controller = new PostsController(postService.Object);
        }

        [TestMethod]
        public void Index()
        {
            this.controller.WithCallTo(c => c.Index(null)).ShouldRenderDefaultView().WithModel<List<PostViewModel>>();
        }
    }
}