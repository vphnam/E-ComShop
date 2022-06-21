using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class ProductDescriptionService : Service, IProductDescriptionService
    {
        private readonly IProductDescriptionRepository _proDescRepo;
        public ProductDescriptionService(IProductDescriptionRepository proDescRepo, IMapper mapper):base(mapper)
        {
            _proDescRepo = proDescRepo;
        }

        public async Task<List<ProductDescDto>> GetAllProductDescriptionAsync()
        {
            var proDesc = await _proDescRepo.GetAllAsync();
            return _mapper.Map<List<ProductDescDto>>(proDesc);
        }

        public async Task<ProductDescDto> GetProductDescriptionRecordByNoAsync(string productDescNo, string productNo)
        {
            var proDesc = await _proDescRepo.GetRecordByNoAsync(productDescNo, productNo);
            if (proDesc != null)
            {
                return _mapper.Map<ProductDescDto>(proDesc);
            }
            else
                throw new Exception(string.Format("Product description no {0} not found", productDescNo));

        }

        public async Task<ProductDescDto> InsertNewProductDescriptionAsync(ProductDescDto entityDto)
        {
            var proDesc = _mapper.Map<ProductDescription>(entityDto);
            var returnObj = await _proDescRepo.InsertNewAsync(proDesc);
            return _mapper.Map<ProductDescDto>(returnObj);
        }

        public async Task<ProductDescDto> UpdateProductDescriptionAsync(ProductDescDto entityDto)
        {
            var proDesc = _mapper.Map<ProductDescription>(entityDto);
            var returnObj = await _proDescRepo.UpdateAsync(proDesc);
            return _mapper.Map<ProductDescDto>(returnObj);
        }

        public async Task<ProductDescDto> DeleteProductDescriptionAsync(ProductDescDto entityDto)
        {
            var proDesc = _mapper.Map<ProductDescription>(entityDto);
            var returnObj = await _proDescRepo.DeleteAsync(proDesc);
            return _mapper.Map<ProductDescDto>(returnObj);
        }
    }
}
