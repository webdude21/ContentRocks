namespace Web.Tests.Controllers
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using Moq;

    using Web.Controllers;
    using Services.Contracts;
    using System.Linq;

    using global::Models.Content;
    using System.Collections.Generic;
    using Web.Models.Content;
    using Common;
    using Common.Contracts;
    using Services;
    using Web.Infrastructure.Constants;

    [TestClass]
    public class PostsControllerTest
    {
        private PostsController controller;

        private Mock<IPostService> postService;

        private readonly IContentFactory dataGenerator;

        private IQueryable<Post> mockData;

        public PostsControllerTest()
        {
            this.dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
        }

        [TestInitialize()]
        public void Initialize()
        {
            this.mockData = GetPosts(20);
            this.postService = new Mock<IPostService>();
            this.postService.As<IPostService>().Setup(m => m.GetTheLatestPosts()).Returns(this.mockData);
            controller = new PostsController(this.postService.Object);
        }

        [TestMethod]
        public void Index()
        {
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }

        private IQueryable<Post> GetPosts(int count)
        {
            var postList = new List<Post>();

            for (var i = 1; i <= count; i++)
            {
                postList.Add(this.dataGenerator.GetPost(i));
            }

            return postList.AsQueryable();
        }
    }
}