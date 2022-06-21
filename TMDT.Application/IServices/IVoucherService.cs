using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IVoucherService
    {
        Task<List<VoucherDto>> GetAllVoucherAsync();
        Task<VoucherDto> GetVoucherRecordByNoAsync(string no);
        Task<VoucherDto> InsertNewVoucherAsync(VoucherDto entityDto);
        Task<VoucherDto> UpdateVoucherAsync(VoucherDto entityDto);
        Task<VoucherDto> DeleteVoucherAsync(VoucherDto entityDto);
    }
}
