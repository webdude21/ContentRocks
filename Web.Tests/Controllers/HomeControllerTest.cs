namespace Web.Tests.Controllers
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;

    using Web.Controllers;

    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;

        [TestInitialize()]
        public void Initialize()
        {
            controller = new HomeController();
        }

        [TestMethod]
        public void About()
        {
            controller.WithCallTo(c => c.About()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Contact()
        {
            controller.WithCallTo(c => c.Contact()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Index()
        {
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }
    }
}