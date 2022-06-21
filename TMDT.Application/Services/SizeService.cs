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
    public class SizeService : Service, ISizeService
    {
        private readonly ISizeRepository _sizeRepo;
        private readonly SizeManager _sizeManager;
        public SizeService(ISizeRepository sizeRepo, IMapper mapper, SizeManager sizeManager): base(mapper)
        {
            _sizeRepo = sizeRepo;
            _sizeManager = sizeManager;
        }
        public async Task<List<SizeDto>> GetAllSizeAsync()
        {
            var size = await _sizeRepo.GetAllAsync();
            return _mapper.Map<List<SizeDto>>(size);
        }

        public async Task<SizeDto> GetSizeRecordByNoAsync(string no)
        {
            var size = await _sizeRepo.GetRecordByNoAsync(no);

            if (size != null)
            {
                return _mapper.Map<SizeDto>(size);
            }
            else
                throw new Exception(string.Format("Size no {0} not found", no));
        }
        public async Task<SizeDto> InsertNewSizeAsync(SizeDto entityDto)
        {
            var size = await _sizeManager.AddSizeAsync(entityDto);
            var returnData = await _sizeRepo.InsertNewAsync(size);
            return _mapper.Map<SizeDto>(returnData);
        }

        public async Task<SizeDto> UpdateSizeAsync(SizeDto entityDto)
        {
            var size = await _sizeManager.UpdateSizeAsync(entityDto);
            var returnData = await _sizeRepo.UpdateAsync(size);
            return _mapper.Map<SizeDto>(returnData);
        }
        public async Task<SizeDto> DeleteSizeAsync(SizeDto entityDto)
        {
            var size = await _sizeManager.DeleteSizeAsync(entityDto);
            var returnData = await _sizeRepo.DeleteAsync(size);
            return _mapper.Map<SizeDto>(returnData);
        }
    }
}
