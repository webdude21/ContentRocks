namespace Services.Tests
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common;
    using Common.Contracts;

    using Config;

    using Data.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models.Content;

    using Moq;

    using Services.Contracts;

    [TestClass]
    public class PostServiceTests
    {
        private readonly IContentFactory dataGenerator;

        private readonly IQueryable<Post> mockData;

        private readonly int pageSize;

        private readonly IPostService postService;

        private readonly Mock<DbSet<Post>> repository;

        private readonly Mock<IUnitOfWork> unitOfWorkMock;

        public PostServiceTests()
        {
            this.pageSize = GlobalConstants.PageSize;
            this.dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
            this.mockData = this.dataGenerator.GetPosts(20);
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
        public void GetingAPostByIdRetrievesIt()
        {
            const int PostId = 2;
            var retrievedPost = this.postService.GetBy(PostId);
            Assert.AreEqual(PostId, retrievedPost.Id);
        }

        [TestMethod]
        public void GetPostByIdWithWhenNonExistingReturnsNull()
        {
            var result = this.postService.GetBy(424);
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void GettingAPostByIdAndFriendlyUrlRetrievesIt()
        {
            const int PostId = 2;
            const string FriendlyUrl = "friendlyUrl";
            var post = this.postService.GetBy(PostId);
            post.FriendlyUrl = FriendlyUrl;
            var retrievedPost = this.postService.GetBy(PostId, FriendlyUrl).FirstOrDefault();
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
            Assert.AreEqual(this.postService.GetTheLatestPosts(this.pageSize).ToList().Count, this.pageSize);
        }

        [TestMethod]
        public void PostServiceReturnsCorrectlySortedPosts()
        {
            var resultList = this.postService.GetTheLatestPosts(this.pageSize).ToList();
            var realData = this.mockData.OrderByDescending(post => post.CreatedOn).Take(this.pageSize).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }

        [TestMethod]
        public void PostServiceReturnsCorrectlySortedPostsWithPaging()
        {
            var resultList = this.postService.GetTheLatestPosts(this.pageSize, 2).ToList();
            var realData =
                this.mockData.OrderByDescending(post => post.CreatedOn).Skip(this.pageSize).Take(this.pageSize).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }

        [TestMethod]
        public void PostServiceReturnsPageCountCorrectly()
        {
            var pageCount = this.postService.GetPageCount(this.pageSize);
            Assert.AreEqual((this.mockData.Count() + this.pageSize - 1) / this.pageSize, pageCount);
        }

        [TestMethod]
        public void PostServiceReturnsPagerObjectCorrectly()
        {
            var pagerObject = this.postService.GetPager(1);
            Assert.AreEqual(1, pagerObject.CurrentPage);
            Assert.AreEqual((this.mockData.Count() + this.pageSize - 1) / this.pageSize, pagerObject.TotalPages);
        }

        [TestMethod]
        public void PostServiceWithInvalidPageNumberReturnsFirstPage()
        {
            var resultList = this.postService.GetTheLatestPosts(this.pageSize, -122).ToList();
            var realData = this.mockData.OrderByDescending(post => post.CreatedOn).Take(this.pageSize).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }
    }
}