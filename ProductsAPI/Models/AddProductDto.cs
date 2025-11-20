namespace ProductsAPI.Models
{
    public class AddProductDto
    {
        public required string Name { get; set; }

        public required decimal Price { get; set; }
    }
}
