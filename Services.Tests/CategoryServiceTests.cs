namespace Services.Tests
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Common;

    using Data.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models.Content;

    using Moq;

    using Services.Contracts;

    [TestClass]
    public class CategoryServiceTests
    {
        private const int PageSize = 10;

        private readonly DataGenerator dataGenerator;

        private readonly IQueryable<Category> mockData;

        private readonly ICategoryService categoryService;

        private readonly Mock<DbSet<Category>> repository;

        private readonly Mock<IUnitOfWork> unitOfWorkMock;

        public CategoryServiceTests()
        {
            this.dataGenerator = new DataGenerator(RandomDataGenerator.Instance);
            this.mockData = this.GetCategories(20);
            this.unitOfWorkMock = new Mock<IUnitOfWork>();
            this.repository = new Mock<DbSet<Category>>();
            this.repository.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(this.mockData.Provider);
            this.repository.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(this.mockData.Expression);
            this.repository.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(this.mockData.ElementType);
            this.repository.As<IQueryable<Category>>()
                .Setup(m => m.GetEnumerator())
                .Returns(this.mockData.GetEnumerator());
            this.unitOfWorkMock.Setup(uow => uow.Set<Category>()).Returns(this.repository.Object);
            this.categoryService = new CategoryService(this.unitOfWorkMock.Object);
        }

        [TestMethod]
        public void CategoryServiceReturnsAllCategories()
        {
            var resultList = this.categoryService.GetAllCategories().ToList();
            var realData = this.mockData.OrderByDescending(post => post.CreatedOn).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }

        private IQueryable<Category> GetCategories(int count)
        {
            var postList = new List<Category>();

            for (var i = 1; i <= count; i++)
            {
                postList.Add(this.dataGenerator.GetCategory(i));
            }

            return postList.AsQueryable();
        }
    }
}