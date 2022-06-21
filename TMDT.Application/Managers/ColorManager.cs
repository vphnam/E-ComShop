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
    public class ColorManager
    {
        private readonly IColorRepository _colorRepo;
        private readonly IMapper _mapper;
        public ColorManager(IColorRepository colorRepo, IMapper mapper)
        {
            _colorRepo = colorRepo;
            _mapper = mapper;
        }
        public async Task<Color> AddColorAsync(ColorDto colorDto)
        {
            var check = await _colorRepo.CheckExistNameAsync(colorDto.ColorNo, colorDto.ColorName);
            if (!check.Any())
            {
                return _mapper.Map<Color>(colorDto);
            }
            else
                throw new Exception(string.Format("Color name {0} already exist", colorDto.ColorName));

        }
        public async Task<Color> UpdateColorAsync(ColorDto colorDto)
        {
            var check = await _colorRepo.CheckExistNameAsync(colorDto.ColorNo, colorDto.ColorName);
            if (!check.Any())
            {
                return _mapper.Map<Color>(colorDto);
            }
            else
                throw new Exception(string.Format("Color name {0} already exist", colorDto.ColorName));
        }
        public async Task<Color> DeleteSizeAsync(ColorDto colorDto)
        {
            return _mapper.Map<Color>(colorDto);
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
