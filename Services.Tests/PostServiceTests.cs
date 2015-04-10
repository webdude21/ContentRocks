namespace Services.Tests
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Common;

    using Data.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models;

    using Moq;

    using Services.Contracts;

    [TestClass]
    public class PostServiceTests
    {
        private readonly DataGenerator dataGenerator;

        private readonly IQueryable<Post> mockData;

        private readonly IPostService postService;

        public PostServiceTests()
        {
            this.dataGenerator = new DataGenerator();
            this.mockData = this.GetPosts(20);
            var unitOfWorkMock = new Mock<IDbContext>();
            var repositoryMock = new Mock<DbSet<Post>>();
            repositoryMock.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(this.mockData.Provider);
            repositoryMock.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(this.mockData.Expression);
            repositoryMock.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(this.mockData.ElementType);
            repositoryMock.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(this.mockData.GetEnumerator());
            unitOfWorkMock.Setup(uow => uow.Set<Post>()).Returns(repositoryMock.Object);
            this.postService = new PostService(unitOfWorkMock.Object);
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

        [TestMethod]
        public void PostServiceReturnsCorrectlyCountOfPosts()
        {
            Assert.AreEqual(this.postService.GetTheLatestPosts(10, 0).ToList().Count, 10);
        }

        [TestMethod]
        public void PostServiceReturnsCorrectlySortedPosts()
        {
            var resultList = this.postService.GetTheLatestPosts(10, 0).ToList();
            var realData = this.mockData.OrderByDescending(post => post.DateStamp.CreatedOn).Take(10).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }

        [TestMethod]
        public void PostServiceReturnsCorrectlySortedPostsWithPaging()
        {
            var resultList = this.postService.GetTheLatestPosts(10, 1).ToList();
            var realData = this.mockData.OrderByDescending(post => post.DateStamp.CreatedOn).Skip(10).Take(10).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }
    }
}