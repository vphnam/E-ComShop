using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IColorService
    {
        Task<List<ColorDto>> GetAllColorAsync();
        Task<ColorDto> GetColorRecordByNoAsync(string no);
        Task<ColorDto> InsertNewColorAsync(ColorDto entityDto);
        Task<ColorDto> UpdateColorAsync(ColorDto entityDto);
        Task<ColorDto> DeleteColorAsync(ColorDto entityDto);
    }
}