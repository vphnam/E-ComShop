using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface ITypeService
    {
        Task<List<TypeDto>> GetAllTypeAsync();
        Task<TypeDto> GetTypeRecordByNoAsync(string no);
        Task<TypeDto> InsertNewTypeAsync(TypeDto entityDto);
        Task<TypeDto> UpdateTypeAsync(TypeDto entityDto);
        Task<TypeDto> DeleteTypeAsync(TypeDto entityDto);
    }
}
