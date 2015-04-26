namespace Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Common;
    using Common.Contracts;

    using Data.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models.Content;

    using Moq;

    using Services.Contracts;

    [TestClass]
    public class PostServiceTests
    {
        private const int PageSize = 10;

        private readonly IContentFactory dataGenerator;

        private readonly IQueryable<Post> mockData;

        private readonly IPostService postService;

        private readonly Mock<DbSet<Post>> repository;

        private readonly Mock<IUnitOfWork> unitOfWorkMock;

        public PostServiceTests()
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
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingFailsWithExceptionIfIdIsTaken()
        {
            var post = this.dataGenerator.GetPost(PageSize);
            this.repository.As<IDbSet<Post>>().Setup(m => m.Find(PageSize)).Returns(post);
            this.postService.AddPost(post);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullAsUnitOfWorkThrowsException()
        {
            new CategoryService(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullPostThrowsException()
        {
            this.postService.AddPost(null);
        }

        [TestMethod]
        public void AddingPostWorks()
        {
            var post = this.dataGenerator.GetPost(200);
            this.repository.Setup(m => m.Add(post)).Verifiable();
            this.unitOfWorkMock.Setup(m => m.SaveChanges()).Verifiable();
            this.postService.AddPost(post);
            this.repository.Verify();
        }

        [TestMethod]
        public void GetingAPostByIdRetreivesIt()
        {
            var postId = 2;
            var retrievedPost = this.postService.GetPostBy(postId).FirstOrDefault();
            Assert.AreEqual(postId, retrievedPost.Id);
        }

        [TestMethod]
        public void GetPostByIdWithWhenNonExistingReturnsNull()
        {
            var result = this.postService.GetPostBy(-43424).FirstOrDefault();
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void GettingAPostByIdAndFriendlyUrlRetrievesIt()
        {
            var postId = 2;
            var friendlyUrl = "friendlyUrl";
            var post = this.postService.GetPostBy(postId).FirstOrDefault();
            post.FriendlyUrl = friendlyUrl;
            var retrievedPost = this.postService.GetPostBy(postId, friendlyUrl).FirstOrDefault();
            Assert.AreEqual(post, retrievedPost);
        }

        [TestMethod]
        public void PostServiceReturnsAllPostsOrderedByDescendingDate()
        {
            var resultList = this.postService.GetTheLatestPosts().ToList();
            var realData = this.mockData.OrderByDescending(post => post.CreatedOn).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }

        [TestMethod]
        public void PostServiceReturnsCorrectlyCountOfPosts()
        {
            Assert.AreEqual(this.postService.GetTheLatestPosts(PageSize).ToList().Count, PageSize);
        }

        [TestMethod]
        public void PostServiceReturnsCorrectlySortedPosts()
        {
            var resultList = this.postService.GetTheLatestPosts(PageSize).ToList();
            var realData = this.mockData.OrderByDescending(post => post.CreatedOn).Take(PageSize).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }

        [TestMethod]
        public void PostServiceReturnsCorrectlySortedPostsWithPaging()
        {
            var resultList = this.postService.GetTheLatestPosts(PageSize, 2).ToList();
            var realData =
                this.mockData.OrderByDescending(post => post.CreatedOn).Skip(PageSize).Take(PageSize).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }

        [TestMethod]
        public void PostServiceWithInvalidPageNumberReturnsFirstPage()
        {
            var resultList = this.postService.GetTheLatestPosts(PageSize, -122).ToList();
            var realData = this.mockData.OrderByDescending(post => post.CreatedOn).Take(PageSize).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
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