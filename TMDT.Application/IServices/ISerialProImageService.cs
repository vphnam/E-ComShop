using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface ISerialProImageService
    {
        Task<List<SerialProImageDto>> GetAllSerialProImgAsync();
        Task<SerialProImageDto> GetSerialProImgRecordByNoAsync(string serialNo, string serialProImgNo);
        Task<SerialProImageDto> InsertNewSerialProImgAsync(SerialProImageDto entityDto);
        Task<SerialProImageDto> UpdateSerialProImgAsync(SerialProImageDto entityDto);
        Task<SerialProImageDto> DeleteSerialProImgAsync(SerialProImageDto entityDto);
    }
}
