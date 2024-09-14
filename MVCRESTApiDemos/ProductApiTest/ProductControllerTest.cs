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
        Product product;
        List<Product>products=new List<Product>();  
        [OneTimeSetUp]
        public void Init()
        {
           product = new Product() { Code = 1, Name = "Torn Jeans", Price = 499, Image = "http://someurl.com" };
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
            var service = new Mock<IProductService>();
            controller = new ProductController(service.Object);
            service.Setup(s => s.AddProduct(It.IsAny<Product>())).Returns((Product p) =>
            {
                products.Add(p);
                return true;
            });
            controller.Post(product);
            controller.Post(new Product()
            { Code = 2, Name = "Blue Jeans", Price = 499, Image = "http://someurl.com" });
            service.Setup(s => s.GetProductById(It.IsAny<int>())).Returns((int id) =>
            {
             return   products.Where(p=>p.Code==id).FirstOrDefault();
            });
            //Assert.That(products.Count, Is.EqualTo(2));//constrained
            var result = controller.Get(2);
            Assert.That(result,Is.InstanceOf<ActionResult<Product>>());
        }
        [Test]
        public void TestGetWithIdNegative()
        {
            var service = new Mock<IProductService>();
            controller = new ProductController(service.Object);
            service.Setup(s => s.AddProduct(It.IsAny<Product>())).Returns((Product p) =>
            {
                products.Add(p);
                return true;
            });
            controller.Post(product);
            controller.Post(new Product()
            { Code = 2, Name = "Blue Jeans", Price = 499, Image = "http://someurl.com" });
            service.Setup(s => s.GetProductById(It.IsAny<int>())).Returns((int id) =>
            {
                return products.Where(p => p.Code == id).FirstOrDefault();
            });
            ActionResult<Product> result= controller.Get(3);
            Assert.That(result.Result,Is.AssignableFrom<NotFoundResult>());
            Assert.That(result.Value,Is.Null);
        }
        [Test]
        public void TestPostPositive()
        {
            //Product product = new Product() { Code = 1 ,Name="Torn Jeans",Price=499,Image="http://someurl.com"};
            
            var service = new Mock<IProductService>();
            controller = new ProductController(service.Object);
            service.Setup(s=>s.AddProduct(It.IsAny<Product>())).Returns(true);
            var result = controller.Post(product);
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
        }
        [Test]
        public void TestPostNegative()
        {        
            var service = new Mock<IProductService>();
            controller = new ProductController(service.Object);
            service.Setup(s => s.AddProduct(It.IsAny<Product>())).Returns(true);
            var result = controller.Post(null);
            Assert.IsInstanceOf<BadRequestResult>(result);
        }
        [TearDown]
        public void Clean() { }
        [OneTimeTearDown]
        public void FinalCleanup() { }
    }
}