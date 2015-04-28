namespace Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    using Common;
    using Common.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models.Content;

    using Moq;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using TestStack.FluentMVCTesting;

    using Web.Controllers;
    using Web.ViewModels.Content;
    using Data.Contracts;
    using Services;

    [TestClass]
    public class PostsControllerTest
    {
        private readonly IContentFactory dataGenerator;

        private PostsController controller;

        private IQueryable<Post> mockData;

        private readonly Mock<DbSet<Post>> repository;

        private IPostService postService;

        private Mock<IUnitOfWork> unitOfWorkMock;

        public PostsControllerTest()
        {
            this.dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
            this.mockData = this.GetPosts(20);
            this.unitOfWorkMock = new Mock<IUnitOfWork>();
            this.repository = new Mock<DbSet<Post>>();
            this.repository.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(this.mockData.Provider);
            this.repository.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(this.mockData.Expression);
            this.repository.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(this.mockData.ElementType);
            this.repository.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(this.mockData.GetEnumerator());
            this.unitOfWorkMock.Setup(uow => uow.Set<Post>()).Returns(this.repository.Object);
            this.postService = new PostService(this.unitOfWorkMock.Object);
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute();
            this.controller = new PostsController(this.postService);
        }

        [TestMethod]
        public void Index()
        {
            this.controller.WithCallTo(c => c.Index(null)).ShouldRenderDefaultView().WithModel<List<PostViewModel>>();
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