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
    public class SizeController :BaseController
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _sizeService = sizeService;
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var sizeDtoList = await _sizeService.GetAllSizeAsync();
                var returnData = _mapper.Map<List<SizeViewModel>>(sizeDtoList);
                return new ResultViewModel<List<SizeViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get size list successfully!", returnData);
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
                var sizeDto = await _sizeService.GetSizeRecordByNoAsync(no);
                var returnData = _mapper.Map<SizeViewModel>(sizeDto);
                return new ResultViewModel<SizeViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with size no: {0} successfully",no), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(SizeViewModel sizeViewModel)
        {
            try
            {
                sizeViewModel.SizeNo = "1";
                var sizeDto = await _sizeService.InsertNewSizeAsync(_mapper.Map<SizeDto>(sizeViewModel));
                var returnData = _mapper.Map<SizeViewModel>(sizeDto);
                return new ResultViewModel<SizeViewModel>(ViewModels.Base.StatusCode.OK, "Done: New size has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(SizeViewModel sizeViewModel)
        {
            try
            {
                var sizeDto = await _sizeService.UpdateSizeAsync(_mapper.Map<SizeDto>(sizeViewModel));
                var returnData = _mapper.Map<SizeViewModel>(sizeDto);
                return new ResultViewModel<SizeViewModel>(ViewModels.Base.StatusCode.OK, "Done: Size has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(SizeViewModel sizeViewModel)
        {
            try
            {
                var sizeDto = await _sizeService.DeleteSizeAsync(_mapper.Map<SizeDto>(sizeViewModel));
                var returnData = _mapper.Map<SizeViewModel>(sizeDto);
                return new ResultViewModel<SizeViewModel>(ViewModels.Base.StatusCode.OK, "Done: Size has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
