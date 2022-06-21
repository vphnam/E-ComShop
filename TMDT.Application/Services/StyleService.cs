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
    public class StyleService: Service, IStyleService
    {
        private readonly IStyleRepository _styleRepo;
        private readonly StyleManager _styleManager;
        public StyleService(IStyleRepository styleRepo, StyleManager styleManager, IMapper mapper):base(mapper)
        {
            _styleRepo = styleRepo;
            _styleManager = styleManager;
        }
        public async Task<List<StyleDto>> GetAllStyleAsync()
        {
            var styles = await _styleRepo.GetAllAsync();
            return _mapper.Map<List<StyleDto>>(styles);
        }

        public async Task<StyleDto> GetStyleRecordByNoAsync(string no)
        {
            var style = await _styleRepo.GetRecordByNoAsync(no);

            if (style != null)
            {
                return _mapper.Map<StyleDto>(style);
            }
            else
                throw new Exception(string.Format("Style no {0} not found", no));

        }

        public async Task<StyleDto> InsertNewStyleAsync(StyleDto entityDto)
        {
            var style = await _styleManager.AddStyleAsync(entityDto);
            var returnData = await _styleRepo.InsertNewAsync(style);
            return _mapper.Map<StyleDto>(returnData);
        }

        public async Task<StyleDto> UpdateStyleAsync(StyleDto entityDto)
        {
            var style = await _styleManager.UpdateStyleAsync(entityDto);
            var returnData = await _styleRepo.UpdateAsync(style);
            return _mapper.Map<StyleDto>(returnData);
        }
        public async Task<StyleDto> DeleteStyleAsync(StyleDto entityDto)
        {
            var style = await _styleManager.DeleteStyleAsync(entityDto);
            var returnData = await _styleRepo.DeleteAsync(style);
            return _mapper.Map<StyleDto>(returnData);
        }
    }
}
