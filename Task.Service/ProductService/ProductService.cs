using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task.Core.Entities;
using Task.Infrastructure.Contracts;
using Task.Service.ProductService.Dto;

namespace Task.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepo<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IGenericRepo<Product> productRepo)
        {
            _mapper = mapper;
            _productRepo = productRepo;
        }

        public async Task<ProductResultDto> AddProduct(ProductDto productDto)
        {
            try
            {
                var mappedProduct = _mapper.Map<Product>(productDto);
                mappedProduct.PictureUrl = DocumentSettings.UploadFile(productDto.ImageFile, "Uploads");

                await _productRepo.Add(mappedProduct);

                var productToReturn = _mapper.Map<ProductResultDto>(mappedProduct);
                return productToReturn;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        public async Task<ProductResultDto> UpdateProduct(int id, ProductDto productDto)
        {
            var existintProduct = await _productRepo.GetByIdAsync(id);
            if (existintProduct == null)
                throw new Exception("Product Doesnt Exist");
            _mapper.Map(productDto,existintProduct);
            DocumentSettings.DeleteFile("Uploads", existintProduct.PictureUrl);
            existintProduct.PictureUrl = DocumentSettings.UploadFile(productDto.ImageFile, "Uploads");
            await _productRepo.Update(existintProduct);
            return _mapper.Map<ProductResultDto>(existintProduct);
        }

        public async Task<IReadOnlyList<ProductResultDto>> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllAsync();
            var mappedProdcts = _mapper.Map<IReadOnlyList<ProductResultDto>>(products);
            
            return mappedProdcts;
        }
        public async Task<IReadOnlyList<ProductResultDto>> DeleteProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product is null)
                return null;

            _productRepo.Delete(product);
            DocumentSettings.DeleteFile("Uploads", product.PictureUrl);

            var products = await GetAllProductsAsync();
            return products;
        }


        public async Task<ProductResultDto> GetProductByIdAsync(int? id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            var mappedProduct = _mapper.Map<ProductResultDto>(product);
            return mappedProduct;
        }

    }
}
