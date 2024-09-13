using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {
        bool AddProduct(Product product);
        bool DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        bool UpdateProduct(int id, Product p);
    }
}