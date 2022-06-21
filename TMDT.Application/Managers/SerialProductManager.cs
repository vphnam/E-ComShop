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
    public class SerialProductManager
    {
        private readonly ISerialProductRepository _serialProRepo;
        private readonly IMapper _mapper;
        public SerialProductManager(ISerialProductRepository serialProRepo, IMapper mapper)
        {
            _serialProRepo = serialProRepo;
            _mapper = mapper;
        }
        public async Task<SerialProduct> AddSerialProductAsync(SerialProductDto serialProDto)
        {
            var check = await _serialProRepo.CheckUnique(serialProDto.SerialNo, serialProDto.ProductNo, serialProDto.SizeNo, serialProDto.ColorNo);
            if (!check.Any())
            {
                return _mapper.Map<SerialProduct>(serialProDto);
            }
            else
                throw new Exception(string.Format("Serial product with values {0}, {1}, {2} already exist", serialProDto.ProductNo, serialProDto.SizeNo, serialProDto.ColorNo));
        }
        public async Task<SerialProduct> UpdateSerialProductAsync(SerialProductDto serialProDto)
        {
            var check = await _serialProRepo.CheckUnique(serialProDto.SerialNo, serialProDto.ProductNo, serialProDto.SizeNo, serialProDto.ColorNo);
            if (!check.Any())
            {
                return _mapper.Map<SerialProduct>(serialProDto);
            }
            else
                throw new Exception(string.Format("Serial product with values {0}, {1}, {2} already exist", serialProDto.ProductNo, serialProDto.SizeNo, serialProDto.ColorNo));
        }
        public async Task<SerialProduct> DeleteSerialProductAsync(SerialProductDto serialProDto)
        {
            return _mapper.Map<SerialProduct>(serialProDto);
        }
    }
}
