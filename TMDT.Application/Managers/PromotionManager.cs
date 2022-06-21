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
    public class PromotionManager
    {
        private readonly IPromotionRepository _promotionRepo;
        private readonly IMapper _mapper;
        public PromotionManager(IPromotionRepository promotionRepo, IMapper mapper)
        {
            _promotionRepo = promotionRepo;
            _mapper = mapper;
        }
        public async Task<Promotion> AddPromotionAsync(PromotionDto promoDto)
        {
            var check = await _promotionRepo.CheckExistNameAsync(promoDto.PromotionNo, promoDto.PromotionName);
            if (!check.Any())
            {
                return _mapper.Map<Promotion>(promoDto);
            }
            else
                throw new Exception(string.Format("Promotion name {0} already exist", promoDto.PromotionName));

        }
        public async Task<Promotion> UpdatePromotionAsync(PromotionDto promoDto)
        {
            var check = await _promotionRepo.CheckExistNameAsync(promoDto.PromotionNo, promoDto.PromotionName);
            if (!check.Any())
            {
                return _mapper.Map<Promotion>(promoDto);
            }
            else
                throw new Exception(string.Format("Promotion name {0} already exist", promoDto.PromotionName));
        }
        public async Task<Promotion> DeletePromotionAsync(PromotionDto promoDto)
        {
            return _mapper.Map<Promotion>(promoDto);
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
