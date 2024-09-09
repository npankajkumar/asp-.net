using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService
    {
        private readonly ProductContext _context= new ProductContext();
        public List<Product> GetAllProducts()
        {
           return _context.Products.ToList();//sql select operation
        }
        public bool AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();//sql insert operation
            return true;
        }
    }
}
