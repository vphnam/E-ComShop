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
    public class StyleManager
    {
        private readonly IStyleRepository _styleRepo;
        private readonly IMapper _mapper;
        public StyleManager(IStyleRepository styleRepo, IMapper mapper)
        {
            _styleRepo = styleRepo;
            _mapper = mapper;
        }
        public async Task<Style> AddStyleAsync(StyleDto styleDto)
        {
            var check = await _styleRepo.CheckExistNameAsync(styleDto.StyleNo, styleDto.StyleName);
            if (!check.Any())
            {
                return _mapper.Map<Style>(styleDto);
            }
            else
                throw new Exception(string.Format("Style name {0} already exist", styleDto.StyleName));
        }
        public async Task<Style> UpdateStyleAsync(StyleDto styleDto)
        {
            var check = await _styleRepo.CheckExistNameAsync(styleDto.StyleNo, styleDto.StyleName);
            if (!check.Any())
            {
                return _mapper.Map<Style>(styleDto);
            }
            else
                throw new Exception(string.Format("Style name {0} already exist", styleDto.StyleName));
        }
        public async Task<Style> DeleteStyleAsync(StyleDto styleDto)
        {
            return _mapper.Map<Style>(styleDto);
        }
    }
}
