namespace Services.Tests
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common;
    using Common.Contracts;

    using Data.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models.Content;

    using Moq;

    using Contracts;

    [TestClass]
    public class CategoryServiceTests
    {
        public const int CategoriesCount = 10;

        private readonly ICategoryService categoryService;

        private readonly IContentFactory dataGenerator;

        private readonly IQueryable<Category> mockData;

        private readonly Mock<DbSet<Category>> repository;

        private readonly Mock<IUnitOfWork> unitOfWorkMock;

        public CategoryServiceTests()
        {
            this.dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
            this.mockData = this.dataGenerator.GetCategories(CategoriesCount);
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
        public void AddingCategoryWorks()
        {
            var category = this.dataGenerator.GetCategory(200);
            this.repository.Setup(m => m.Add(category)).Verifiable();
            this.unitOfWorkMock.Setup(m => m.SaveChanges()).Verifiable();
            this.categoryService.AddCategory(category);
            this.repository.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingFailsWithExceptionIfIdIsTaken()
        {
            var category = this.dataGenerator.GetCategory(222);
            this.repository.As<IDbSet<Category>>().Setup(m => m.Find(222)).Returns(category);
            this.categoryService.AddCategory(category);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullCategoryThrowsException()
        {
            this.categoryService.AddCategory(null);
        }

        [TestMethod]
        public void CategoryServiceDeletesItemById()
        {
            var categoryToDelete = this.mockData.FirstOrDefault();
            var id = categoryToDelete.Id;
            this.repository.Setup(c => c.Find(id)).Returns(categoryToDelete);
            this.repository.Setup(c => c.Remove(categoryToDelete)).Verifiable();
            this.unitOfWorkMock.Setup(m => m.SaveChanges()).Verifiable();
            this.categoryService.DeleteBy(id);
            this.repository.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CategoryServiceDeletesItemByIdNonExistingIdThrowsException()
        {
            this.categoryService.DeleteBy(-10);
        }

        [TestMethod]
        public void CategoryServiceReturnsAllCategories()
        {
            var resultList = this.categoryService.GetAll().ToList();
            var realData = this.mockData.OrderByDescending(category => category.CreatedOn).ToList();
            CollectionAssert.AreEquivalent(resultList, realData);
        }
    }
}