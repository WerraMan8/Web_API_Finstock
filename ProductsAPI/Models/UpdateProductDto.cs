namespace ProductsAPI.Models
{
    public class UpdateProductDto
    {
        public required string Name { get; set; }

        public required decimal Price { get; set; }
    }
}
