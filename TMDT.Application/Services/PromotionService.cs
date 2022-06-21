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
    public class PromotionService: Service, IPromotionService
    {
        private readonly IPromotionRepository _proRepo;
        private readonly PromotionManager _proManager;
        public PromotionService(IPromotionRepository proRepo, PromotionManager proManager, IMapper mapper):base(mapper)
        {
            _proRepo = proRepo;
            _proManager = proManager;
        }
        public async Task<List<PromotionDto>> GetAllPromotionAsync()
        {
            var list = await _proRepo.GetAllAsync();
            return _mapper.Map<List<PromotionDto>>(list);
        }

        public async Task<PromotionDto> GetPromotionRecordByNoAsync(string no)
        {
            var promotion = await _proRepo.GetRecordByNoAsync(no);

            if (promotion != null)
            {
                return _mapper.Map<PromotionDto>(promotion);
            }
            else
                throw new Exception(string.Format("Promotion no {0} not found", no));

        }

        public  async Task<PromotionDto> InsertNewPromotionAsync(PromotionDto entityDto)
        {
            var promotion = await _proManager.AddPromotionAsync(entityDto);
            var returnData = await _proRepo.InsertNewAsync(promotion);
            return _mapper.Map<PromotionDto>(returnData);
        }

        public async Task<PromotionDto> UpdatePromotionAsync(PromotionDto entityDto)
        {
            var promotion = await _proManager.UpdatePromotionAsync(entityDto);
            var returnData = await _proRepo.UpdateAsync(promotion);
            return _mapper.Map<PromotionDto>(returnData);
        }
        public async Task<PromotionDto> DeletePromotionAsync(PromotionDto entityDto)
        {
            var promotion = await _proManager.DeletePromotionAsync(entityDto);
            var returnData = await _proRepo.DeleteAsync(promotion);
            return _mapper.Map<PromotionDto>(returnData);
        }
    }
}
