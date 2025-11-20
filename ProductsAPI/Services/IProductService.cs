using ProductsAPI.Models.Entity;

namespace ProductsAPI.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product? GetProductById(int id);

        Product AddProduct(Product product);

        Product? UpdateProduct(int id, Product updatedProduct);

        bool DeleteProduct(int id);
    }
}
