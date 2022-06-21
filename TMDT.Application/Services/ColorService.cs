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
    public class ColorService : Service, IColorService
    {
        private readonly IColorRepository _colorRepo;
        private readonly ColorManager _colorManager;
        public ColorService(IColorRepository colorRepo, IMapper mapper, ColorManager colorManager) : base(mapper)
        {
            _colorRepo = colorRepo;
            _colorManager = colorManager;
        }
        public async Task<List<ColorDto>> GetAllColorAsync()
        {
            var size = await _colorRepo.GetAllAsync();
            return _mapper.Map<List<ColorDto>>(size);
        }

        public async Task<ColorDto> GetColorRecordByNoAsync(string no)
        {
            var color = await _colorRepo.GetRecordByNoAsync(no);
            if(color != null)
            {
                return _mapper.Map<ColorDto>(color);
            }
            else
                throw new Exception(string.Format("Color no {0} not found", no));
        }
        public async Task<ColorDto> InsertNewColorAsync(ColorDto entityDto)
        {
            var color = await _colorManager.AddColorAsync(entityDto);
            var returnData = await _colorRepo.InsertNewAsync(color);
            return _mapper.Map<ColorDto>(returnData);
        }

        public async Task<ColorDto> UpdateColorAsync(ColorDto entityDto)
        {
            var color = await _colorManager.UpdateColorAsync(entityDto);
            var returnData = await _colorRepo.UpdateAsync(color);
            return _mapper.Map<ColorDto>(returnData);
        }
        public  async Task<ColorDto> DeleteColorAsync(ColorDto entityDto)
        {
            var color = await _colorManager.DeleteSizeAsync(entityDto);
            var returnData = await _colorRepo.DeleteAsync(color);
            return _mapper.Map<ColorDto>(returnData);
        }
    }
}
