namespace Services.Tests
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Common;

    using Data.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models;
    using Models.SEO;

    using Moq;

    using Services.Contracts;

    [TestClass]
    public class PostServiceTests
    {
        private static RandomDataGenerator randomGenerator;

        private readonly IQueryable<Post> mockData;

        private readonly IPostService postService;

        public PostServiceTests()
        {
            randomGenerator = RandomDataGenerator.Instance;
            this.mockData = GetPosts(20);
            var unitOfWorkMock = new Mock<IDbContext>();
            var repositoryMock = new Mock<DbSet<Post>>();
            repositoryMock.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(this.mockData.Provider);
            repositoryMock.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(this.mockData.Expression);
            repositoryMock.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(this.mockData.ElementType);
            repositoryMock.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(this.mockData.GetEnumerator());
            unitOfWorkMock.Setup(uow => uow.Set<Post>()).Returns(repositoryMock.Object);
            this.postService = new PostService(unitOfWorkMock.Object);
        }

        private static IQueryable<Post> GetPosts(int count)
        {
            var postList = new List<Post>();

            for (var i = 1; i <= count; i++)
            {
                postList.Add(GetPost(i));
            }

            return postList.AsQueryable();
        }

        private static Post GetPost(int id)
        {
            return new Post
                       {
                           DateStamp =
                               new DateStamp
                                   {
                                       CreatedOn = randomGenerator.GeneraDateTime(),
                                       ModifiedOn = randomGenerator.GeneraDateTime()
                                   },
                           Id = id,
                           MetaInfo =
                               new MetaInfo
                                   {
                                       Description = randomGenerator.GetString(4, 10),
                                       Tags =
                                           new List<Tag>
                                               {
                                                   new Tag
                                                       {
                                                           Id = id,
                                                           Name =
                                                               randomGenerator.GetString(3, 10)
                                                       }
                                               },
                                       Title = randomGenerator.GetString(4, 10)
                                   },
                           Title = randomGenerator.GetString(4, 10)
                       };
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