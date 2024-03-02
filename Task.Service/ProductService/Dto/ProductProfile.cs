using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;

namespace Task.Service.ProductService.Dto
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Product, ProductResultDto>()
                .ForMember(dest => dest.PictureUrl, options => options.MapFrom<ProductUrlResolver>());
        }
    }
}
