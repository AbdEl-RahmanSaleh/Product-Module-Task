using Microsoft.AspNetCore.Mvc;
using Task.Service.ProductService;
using Task.Service.ProductService.Dto;

namespace Task.Api.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductResultDto>> AddProduct(ProductDto product)
            => await _productService.AddProduct(product);
        

        [HttpPut("id")]
        public async Task<ActionResult<ProductResultDto>> UpdateProduct(int id,ProductDto product)   
            => await _productService.UpdateProduct(id,product);
        

        [HttpGet]
        public async Task<IReadOnlyList<ProductResultDto>> GetAllProducts()
            => await _productService.GetAllProductsAsync();

        [HttpGet("{id}")]
        public async Task<ProductResultDto> GetProductById(int id)
          => await _productService.GetProductByIdAsync(id);


        [HttpDelete("{id}")]
        public async Task<IReadOnlyList<ProductResultDto>> DeleteProduct(int id)
           => await _productService.DeleteProduct(id);
    }
}
