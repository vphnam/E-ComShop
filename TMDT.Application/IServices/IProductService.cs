using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IProductService
    {
        Task<List<ProductListDto>> GetAllProductAsync();
        Task<ProductDetailDto> GetProductRecordByNoAsync(string no);
        Task<ProductDetailDto> InsertNewProductAsync(ProductDetailDto entityDto);
        Task<ProductDetailDto> UpdateProductAsync(ProductDetailDto entityDto);
        Task<ProductDetailDto> DeleteProductAsync(ProductDetailDto entityDto);
    }
}
