namespace Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Common.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models.Content;

    using Moq;

    using Services.Contracts;

    using TestStack.FluentMVCTesting;

    using Web.Controllers;

    [TestClass]
    public class PostsControllerTest
    {
        private readonly IContentFactory dataGenerator;

        private PostsController controller;

        private IQueryable<Post> mockData;

        private Mock<IPostService> postService;

        public PostsControllerTest()
        {
            this.dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
        }

        [TestMethod]
        public void Index()
        {
            this.controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }

        [TestInitialize]
        public void Initialize()
        {
            this.mockData = this.GetPosts(20);
            this.postService = new Mock<IPostService>();
            this.postService.As<IPostService>().Setup(m => m.GetTheLatestPosts()).Returns(this.mockData);
            this.controller = new PostsController(this.postService.Object);
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