using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Managers
{
    public class ProductManager
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository productrRepo, IMapper mapper)
        {
            _productRepo = productrRepo;
            _mapper = mapper;
        }
        public async Task<Product> AddProductAsync(ProductDetailDto product)
        {
            var check = await _productRepo.CheckExistNameAsync(product.ProductNo, product.ProductName);
            if (!check.Any())
            {
                return _mapper.Map<Product>(product);
            }
            else
                throw new Exception(string.Format("Product name {0} already exist", product.ProductName));

        }
        public async Task<Product> UpdateProductAsync(ProductDetailDto product)
        {
            var check = await _productRepo.CheckExistNameAsync(product.ProductNo, product.ProductName);
            if (!check.Any())
            {
                return _mapper.Map<Product>(product);
            }
            else
                throw new Exception(string.Format("Product name {0} already exist", product.ProductName));
        }
        public async Task<Product> DeleteProductAsync(ProductDetailDto product)
        {
            return _mapper.Map<Product>(product);
            /*var check = await _colorRepo.CheckExistByNo(colorDto.ColorNo);
            if (check.Any())
            {
                return _mapper.Map<Color>(colorDto);
            }
            else
                throw new Exception(string.Format("Color no {0} does not exist", colorDto.ColorNo));*/
        }
    }
}
