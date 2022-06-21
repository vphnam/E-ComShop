using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDT.Application.IServices;
using TMDT.Helpers;
using TMDT.Shared.Dto;
using TMDT.ViewModels;
using TMDT.ViewModels.Base;

namespace TMDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : BaseController
    {
        private readonly IVoucherService _vcService;
        public VoucherController(IVoucherService vcService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _vcService = vcService;
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var vcDtoList = await _vcService.GetAllVoucherAsync();
                var returnData = _mapper.Map<List<VoucherViewModel>>(vcDtoList);
                return new ResultViewModel<List<VoucherViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get voucher list successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetByNo")]
        public async Task<object> GetByNo(string no)
        {
            try
            {
                var vcDto = await _vcService.GetVoucherRecordByNoAsync(no);
                var returnData = _mapper.Map<VoucherViewModel>(vcDto);
                return new ResultViewModel<VoucherViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with voucher no: {0} successfully", no), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(VoucherViewModel vc)
        {
            try
            {
                var vcDto = await _vcService.InsertNewVoucherAsync(_mapper.Map<VoucherDto>(vc));
                var returnData = _mapper.Map<VoucherViewModel>(vcDto);
                return new ResultViewModel<VoucherViewModel>(ViewModels.Base.StatusCode.OK, "Done: New voucher has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(VoucherViewModel vc)
        {
            try
            {
                var vcDto = await _vcService.UpdateVoucherAsync(_mapper.Map<VoucherDto>(vc));
                var returnData = _mapper.Map<VoucherViewModel>(vcDto);
                return new ResultViewModel<VoucherViewModel>(ViewModels.Base.StatusCode.OK, "Done: Voucher has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(VoucherViewModel vc)
        {
            try
            {
                var vcDto = await _vcService.DeleteVoucherAsync(_mapper.Map<VoucherDto>(vc));
                var returnData = _mapper.Map<VoucherViewModel>(vcDto);
                return new ResultViewModel<VoucherViewModel>(ViewModels.Base.StatusCode.OK, "Done: Voucher has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
