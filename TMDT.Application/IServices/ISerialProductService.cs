using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface ISerialProductService
    {
        Task<List<DisplayProductDto>> GetAllSerialProductAsync();
        Task<DisplaySingleProduct> GetSerialProductRecordByNoAsync(string no);
        Task<SerialProductDto> InsertNewSerialProductAsync(SerialProductDto entityDto);
        Task<SerialProductDto> UpdateSerialProductAsync(SerialProductDto entityDto);
        Task<SerialProductDto> DeleteSerialProductAsync(SerialProductDto entityDto);
    }
}
