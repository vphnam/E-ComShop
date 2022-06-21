using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Application.Managers;
using TMDT.Infrastructure.IRepositories;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class VoucherService: Service, IVoucherService
    {
        private readonly IVoucherRepository _vcRepo;
        private readonly VoucherManager _vcManager;
        public VoucherService(IVoucherRepository vcRepo, VoucherManager vcManager, IMapper mapper):base(mapper)
        {
            _vcRepo = vcRepo;
            _vcManager = vcManager;
        }

        public async Task<List<VoucherDto>> GetAllVoucherAsync()
        {
            var list = await _vcRepo.GetAllAsync();
            return _mapper.Map<List<VoucherDto>>(list);
        }

        public async Task<VoucherDto> GetVoucherRecordByNoAsync(string no)
        {
            var vc = await _vcRepo.GetRecordByNoAsync(no);
            return _mapper.Map<VoucherDto>(vc);
        }

        public  async Task<VoucherDto> InsertNewVoucherAsync(VoucherDto entityDto)
        {
            var vc = await _vcManager.AddVoucherAsync(entityDto);
            return _mapper.Map<VoucherDto>(await _vcRepo.InsertNewAsync(vc));
        }

        public async Task<VoucherDto> UpdateVoucherAsync(VoucherDto entityDto)
        {
            var vc = await _vcManager.UpdateVoucherAsync(entityDto);
            return _mapper.Map<VoucherDto>(await _vcRepo.UpdateAsync(vc));
        }
        public async Task<VoucherDto> DeleteVoucherAsync(VoucherDto entityDto)
        {
            var vc = await _vcManager.DeleteVoucherAsync(entityDto);
            return _mapper.Map<VoucherDto>(await _vcRepo.DeleteAsync(vc));
        }
    }
}
