using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IStyleService
    {
        Task<List<StyleDto>> GetAllStyleAsync();
        Task<StyleDto> GetStyleRecordByNoAsync(string no);
        Task<StyleDto> InsertNewStyleAsync(StyleDto entityDto);
        Task<StyleDto> UpdateStyleAsync(StyleDto entityDto);
        Task<StyleDto> DeleteStyleAsync(StyleDto entityDto);
    }
}
