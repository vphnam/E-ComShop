using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IPromotionService
    {
        Task<List<PromotionDto>> GetAllPromotionAsync();
        Task<PromotionDto> GetPromotionRecordByNoAsync(string no);
        Task<PromotionDto> InsertNewPromotionAsync(PromotionDto entityDto);
        Task<PromotionDto> UpdatePromotionAsync(PromotionDto entityDto);
        Task<PromotionDto> DeletePromotionAsync(PromotionDto entityDto);
    }
}
