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
    public class SizeManager
    {
        private readonly ISizeRepository _sizeRepo;
        private readonly IMapper _mapper;
        public SizeManager(ISizeRepository sizeRepo, IMapper mapper)
        {
            _sizeRepo = sizeRepo;
            _mapper = mapper;
        }
        public async Task<Size> AddSizeAsync(SizeDto sizeDto)
        {
            var check = await _sizeRepo.CheckExistNameAsync(sizeDto.SizeNo, sizeDto.SizeName);
            if (!check.Any())
            {
                return _mapper.Map<Size>(sizeDto);
            }
            else
                throw new Exception(string.Format("Size name {0} already exist", sizeDto.SizeName));

        }
        public async Task<Size> UpdateSizeAsync(SizeDto sizeDto)
        {
            var check = await _sizeRepo.CheckExistNameAsync(sizeDto.SizeNo, sizeDto.SizeName);
            if (!check.Any())
            {
                return _mapper.Map<Size>(sizeDto);
            }
            else
                throw new Exception(string.Format("Size name {0} already exist", sizeDto.SizeName));
        }
        public async Task<Size> DeleteSizeAsync(SizeDto sizeDto)
        {
            return _mapper.Map<Size>(sizeDto);
        }
    }
}
