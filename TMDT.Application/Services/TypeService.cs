using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Application.Managers;
using TMDT.Infrastructure.IRepositories;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class TypeService: Service, ITypeService
    {
        private readonly ITypeRepository _typeRepo;
        private readonly TypeManager _typeManager;
        public TypeService(ITypeRepository typeRepo, TypeManager typeManager, IMapper mapper):base(mapper)
        {
            _typeRepo = typeRepo;
            _typeManager = typeManager;
        }
        public async Task<List<TypeDto>> GetAllTypeAsync()
        {
            var type = await _typeRepo.GetAllAsync();
            return _mapper.Map<List<TypeDto>>(type);
        }

        public async Task<TypeDto> GetTypeRecordByNoAsync(string no)
        {
            var type = await _typeRepo.GetRecordByNoAsync(no);

            if (type != null)
            {
                return _mapper.Map<TypeDto>(type);
            }
            else
                throw new System.Exception(string.Format("Type no {0} not found", no));

        }

        public async Task<TypeDto> InsertNewTypeAsync(TypeDto entityDto)
        {
            var type = await _typeManager.AddTypeAsync(entityDto);
            var returnData = await _typeRepo.InsertNewAsync(type);
            return _mapper.Map<TypeDto>(returnData);
        }

        public async Task<TypeDto> UpdateTypeAsync(TypeDto entityDto)
        {
            var type = await _typeManager.UpdateTypeAsync(entityDto);
            var returnData = await _typeRepo.UpdateAsync(type);
            return _mapper.Map<TypeDto>(returnData);
        }
        public async Task<TypeDto> DeleteTypeAsync(TypeDto entityDto)
        {
            var type = await _typeManager.DeleteTypeAsync(entityDto);
            var returnData = await _typeRepo.DeleteAsync(type);
            return _mapper.Map<TypeDto>(returnData);
        }
    }
}
