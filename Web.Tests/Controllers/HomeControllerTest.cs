namespace Web.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestStack.FluentMVCTesting;

    using Web.Controllers;

    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;

        [TestMethod]
        public void About()
        {
            this.controller.WithCallTo(c => c.About()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Contact()
        {
            this.controller.WithCallTo(c => c.Contact()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Index()
        {
            this.controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }

        [TestInitialize]
        public void Initialize()
        {
            this.controller = new HomeController();
        }
    }
}