using ProductApi.Controllers;
using ProductApi.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
namespace ProductApiTest
{
    [TestFixture]
    public class ProductControllerTest
    {
        ProductController controller;
        [OneTimeSetUp]
        public void Init()
        {
            //
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetPositive()
        {
            // mock representation of service
            var service = new Mock<IProductService>();
            controller = new ProductController(service.Object);
            service.Setup(s=> s.GetAllProducts()).Returns(
                new List<Product>() { new Product()});
            var result = controller.Get();
            Assert.IsAssignableFrom<List<Product>>(result);
        }
        [Test]
        public void TestGetNegative()
        {
            var service = new Mock<IProductService>();
            controller = new ProductController(service.Object);
            service.Setup(s => s.GetAllProducts()).Returns(
                new List<Product>() );
            var result = controller.Get();
            Assert.AreEqual(new List<Product>(),result);
        }
        [Test]
        public void TestGetWithIdPositive()
        {
            Assert.Pass();
        }
        [Test]
        public void TestPostPositive()
        {
            Assert.Pass();
        }
        [TearDown]
        public void Clean() { }
        [OneTimeTearDown]
        public void FinalCleanup() { }
    }
}