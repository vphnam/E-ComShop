using System.Collections.Generic;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface ISizeService
    {
        Task<List<SizeDto>> GetAllSizeAsync();
        Task<SizeDto> GetSizeRecordByNoAsync(string no);
        Task<SizeDto> InsertNewSizeAsync(SizeDto entityDto);
        Task<SizeDto> UpdateSizeAsync(SizeDto entityDto);
        Task<SizeDto> DeleteSizeAsync(SizeDto entityDto);
    }
}
