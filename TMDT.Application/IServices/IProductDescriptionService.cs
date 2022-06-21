using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IProductDescriptionService
    {
        Task<List<ProductDescDto>> GetAllProductDescriptionAsync();
        Task<ProductDescDto> GetProductDescriptionRecordByNoAsync(string productDescNo, string productNo);
        Task<ProductDescDto> InsertNewProductDescriptionAsync(ProductDescDto entityDto);
        Task<ProductDescDto> UpdateProductDescriptionAsync(ProductDescDto entityDto);
        Task<ProductDescDto> DeleteProductDescriptionAsync(ProductDescDto entityDto);
    }
}
