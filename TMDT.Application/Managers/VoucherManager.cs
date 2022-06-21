using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Managers
{
    public class VoucherManager
    {
        private readonly IVoucherRepository _vcRepo;
        private readonly IMapper _mapper;
        public VoucherManager(IVoucherRepository vcRepo, IMapper mapper)
        {
            _vcRepo = vcRepo;
            _mapper = mapper;
        }
        public async Task<Voucher> AddVoucherAsync(VoucherDto vcDto)
        {
            vcDto.Status = true;
            var check = await _vcRepo.CheckUniqueName(vcDto.VoucherNo, vcDto.VoucherName);
            if (!check.Any())
            {
                return _mapper.Map<Voucher>(vcDto);
            }
            else
                throw new Exception(string.Format("Voucher name {0} already exist", vcDto.VoucherName));

        }
        public async Task<Voucher> UpdateVoucherAsync(VoucherDto vcDto)
        {
            var check = await _vcRepo.CheckUniqueName(vcDto.VoucherNo, vcDto.VoucherName);
            if (!check.Any())
            {
                return _mapper.Map<Voucher>(vcDto);
            }
            else
                throw new Exception(string.Format("Voucher name {0} already exist", vcDto.VoucherName));
        }
        public async Task<Voucher> DeleteVoucherAsync(VoucherDto vcDto)
        {
            return _mapper.Map<Voucher>(vcDto);
            /*var check = await _colorRepo.CheckExistByNo(colorDto.ColorNo);
            if (check.Any())
            {
                return _mapper.Map<Color>(colorDto);
            }
            else
                throw new Exception(string.Format("Color no {0} does not exist", colorDto.ColorNo));*/
        }
    }
}
