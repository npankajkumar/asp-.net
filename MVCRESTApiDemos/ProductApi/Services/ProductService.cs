using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService
    {
        private readonly ProductContext _context = new ProductContext();
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();//sql select operation
        }
        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }
        public bool AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();//sql insert operation
                return true;
            } catch { return false; }
        }
        public bool UpdateProduct(int id, Product p)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.Name = p.Name;
                product.Price = p.Price;
                product.Image = p.Image;
                _context.SaveChanges();
                return true;
            }
            return false;
            
         
        }
        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
    }
