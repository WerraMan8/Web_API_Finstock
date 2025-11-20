using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Models.Entity;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        //Retrieves all products from the database table
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var allProducts = productService.GetAllProducts();

            return Ok(allProducts);
        }
    
        //Retrieves products from the products table based on the entered ID
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = productService.GetProductById(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //Adds new products to the products table
        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProductDto)
        {

            if (string.IsNullOrWhiteSpace(addProductDto.Name))
            {
                return BadRequest("Name cannot be empty.");
            }

            if (addProductDto.Price <= 0)
            {
                return BadRequest("Price must be greater than 0.");

            }
            var productEntity = new Product()
            {
                Name = addProductDto.Name,
                Price = addProductDto.Price
            };

            productService.AddProduct(productEntity);

            return Ok(productEntity);
        }


        //Updates the information of a product in the products table based on its ID
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            if (string.IsNullOrWhiteSpace(updateProductDto.Name) || updateProductDto.Price <= 0)
            {
                return BadRequest("Invalid Data");
            }

            var productEntity = new Product()
            {
                Name = updateProductDto.Name,
                Price = updateProductDto.Price
            };

            var updatedProduct = productService.UpdateProduct(id, productEntity);
            
            if (updatedProduct is null)
            {
                return NotFound();
            }
            
            return Ok(updatedProduct);
        }


        //Deletes a product from the products table based on its ID
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = productService.DeleteProduct(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
