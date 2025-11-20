using ProductsAPI.Data;
using ProductsAPI.Models.Entity;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product? UpdateProduct(int id, Product updatedProduct)
        {
            var existingProduct = _context.Products.Find(id);

            if (existingProduct is null)
            {
                return null;
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            _context.SaveChanges();
            return updatedProduct;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product is null)
            {
                return false;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
