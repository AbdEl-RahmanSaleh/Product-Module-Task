using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.ProductService.Dto;

namespace Task.Service.ProductService
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductResultDto>> GetAllProductsAsync();
        Task<ProductResultDto> GetProductByIdAsync(int? id);
        Task<ProductResultDto> AddProduct(ProductDto product);
        Task<ProductResultDto> UpdateProduct(int id ,ProductDto product);
        Task<IReadOnlyList<ProductResultDto>> DeleteProduct(int id);
    }
}
