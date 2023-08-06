using CoffeeSalesShop.API.Data.Models;
using CoffeeSalesShop.API.Interfaces;
using CoffeeSalesShop.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeSalesShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts() => Ok(await _productService.GetAllProducts());

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product) => Ok(await _productService.AddProduct(product));
    }
}