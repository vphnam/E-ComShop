using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDT.Infrastructure.IRepositories;
using TMDT.Shared.Dto;

namespace TMDT.Application.Managers
{
    public class TypeManager
    {
        private readonly ITypeRepository _typeRepo;
        private readonly IMapper _mapper;
        public TypeManager(ITypeRepository typeRepo, IMapper mapper)
        {
            _typeRepo = typeRepo;
            _mapper = mapper;
        }
        public async Task<Infrastructure.Models.Type> AddTypeAsync(TypeDto typeDto)
        {
            var check = await _typeRepo.CheckExistNameAsync(typeDto.TypeNo, typeDto.TypeName);
            if (!check.Any())
            {
                return _mapper.Map<Infrastructure.Models.Type>(typeDto);
            }
            else
                throw new Exception(string.Format("Type name {0} already exist", typeDto.TypeName));
        }
        public async Task<Infrastructure.Models.Type> UpdateTypeAsync(TypeDto typeDto)
        {
            var check = await _typeRepo.CheckExistNameAsync(typeDto.TypeNo, typeDto.TypeName);
            if (!check.Any())
            {
                return _mapper.Map<Infrastructure.Models.Type>(typeDto);
            }
            else
                throw new Exception(string.Format("Type name {0} already exist", typeDto.TypeName));
        }
        public async Task<Infrastructure.Models.Type> DeleteTypeAsync(TypeDto typeDto)
        {
            return _mapper.Map<Infrastructure.Models.Type>(typeDto);
        }
    }
}
