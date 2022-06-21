using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Application.Managers;
using TMDT.Infrastructure.IRepositories;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class ProductService: Service, IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly ProductManager _productManager;
        private readonly ITypeRepository _typeRepo;
        private readonly IStyleRepository _styleRepo;
        public ProductService(IProductRepository productRepo, IStyleRepository styleRepo, ITypeRepository typeRepo, ProductManager productManager, IMapper mapper): base(mapper)
        {
            _productRepo = productRepo;
            _styleRepo = styleRepo;
            _typeRepo = typeRepo;
            _productManager = productManager;
        }

        public async Task<List<ProductListDto>> GetAllProductAsync()
        {
            var list = await _productRepo.GetCanChangeListAllAsync();
            foreach(var item in list)
            {
                item.TypeNoNavigation = await _typeRepo.GetRecordByNoAsync(item.TypeNo);
                item.StyleNoNavigation = await _styleRepo.GetRecordByNoAsync(item.StyleNo);
            }
            var retur = _mapper.Map<List<ProductListDto>>(list);
            return retur;
        }

        public async Task<ProductDetailDto> GetProductRecordByNoAsync(string no)
        {
            var product = await _productRepo.GetRecordByNoAsync(no);

            if (product != null)
            {
                return _mapper.Map<ProductDetailDto>(product);
            }
            else
                throw new Exception(string.Format("Product no {0} not found", no));

        }

        public async Task<ProductDetailDto> InsertNewProductAsync(ProductDetailDto entityDto)
        {
            var product = await _productManager.AddProductAsync(entityDto);
            var returnData = await _productRepo.InsertNewAsync(product);
            return _mapper.Map<ProductDetailDto>(returnData);
        }

        public async Task<ProductDetailDto> UpdateProductAsync(ProductDetailDto entityDto)
        {
            var product = await _productManager.UpdateProductAsync(entityDto);
            var returnData = await _productRepo.UpdateAsync(product);
            return _mapper.Map<ProductDetailDto>(returnData);
        }
        public async Task<ProductDetailDto> DeleteProductAsync(ProductDetailDto entityDto)
        {
            var product = await _productManager.DeleteProductAsync(entityDto);
            var returnData = await _productRepo.DeleteAsync(product);
            return _mapper.Map<ProductDetailDto>(returnData);
        }
    }
}
