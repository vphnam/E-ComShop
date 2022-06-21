using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class SerialProImageService: Service, ISerialProImageService
    {
        private readonly ISerialProImageRepository _seProImgRepo;
        public SerialProImageService(ISerialProImageRepository seProImgRepo, IMapper mapper):base(mapper)
        {
            _seProImgRepo = seProImgRepo;
        }

        public async Task<List<SerialProImageDto>> GetAllSerialProImgAsync()
        {
            var list = await _seProImgRepo.GetAllAsync();
            return _mapper.Map<List<SerialProImageDto>>(list);
        }

        public async Task<SerialProImageDto> GetSerialProImgRecordByNoAsync(string serialNo, string serialProImgNo)
        {
            var dto = await _seProImgRepo.GetRecordByNoAsync(serialNo,serialProImgNo);

            if (dto != null)
            {
                return _mapper.Map<SerialProImageDto>(dto);
            }
            else
                throw new Exception(string.Format("Image no {0} not found on serial product {1}", serialProImgNo, serialNo));

        }

        public async Task<SerialProImageDto> InsertNewSerialProImgAsync(SerialProImageDto entityDto)
        {
            var entity = await _seProImgRepo.InsertNewAsync(_mapper.Map<SerialProImage>(entityDto));
            return _mapper.Map<SerialProImageDto>(entity);
        }

        public async Task<SerialProImageDto> UpdateSerialProImgAsync(SerialProImageDto entityDto)
        {
            var entity = await _seProImgRepo.UpdateAsync(_mapper.Map<SerialProImage>(entityDto));
            return _mapper.Map<SerialProImageDto>(entity);
        }
        public async Task<SerialProImageDto> DeleteSerialProImgAsync(SerialProImageDto entityDto)
        {
            var entity = await _seProImgRepo.DeleteAsync(_mapper.Map<SerialProImage>(entityDto));
            return _mapper.Map<SerialProImageDto>(entity);
        }
    }
}
