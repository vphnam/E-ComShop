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
    public class SerialProImageController : BaseController
    {
        private readonly ISerialProImageService _seProImgService;
        public SerialProImageController(ISerialProImageService seProImgService, Helper helper, IMapper mapper):base(mapper,helper)
        {
            _seProImgService = seProImgService;
        }
        [HttpGet]
        public async Task<object> GetList()
        {
            try
            {
                var list = await _seProImgService.GetAllSerialProImgAsync();
                var returnData = _mapper.Map<List<SerialProImageViewModel>>(list);
                return new ResultViewModel<List<SerialProImageViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get product list successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("GetByNo")]
        public async Task<object> GetByNo(GetSerialProImageViewModel getViewModel)
        {
            try
            {
                var seImgDto = await _seProImgService.GetSerialProImgRecordByNoAsync(getViewModel.SerialNo,getViewModel.SerialImageNo);
                var returnData = _mapper.Map<SerialProImageViewModel>(seImgDto);
                return new ResultViewModel<SerialProImageViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with serial no: {0} and image no: {1} successfully", getViewModel.SerialNo, getViewModel.SerialImageNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(SerialProImageViewModel viewModel)
        {
            try
            {
                viewModel.SerialImageNo = _helper.GenerateId();
                var dto = await _seProImgService.InsertNewSerialProImgAsync(_mapper.Map<SerialProImageDto>(viewModel));
                var returnData = _mapper.Map<SerialProImageViewModel>(dto);
                return new ResultViewModel<SerialProImageViewModel>(ViewModels.Base.StatusCode.OK, "Done: New serial image has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(SerialProImageViewModel viewModel)
        {
            try
            {
                var dto = await _seProImgService.UpdateSerialProImgAsync(_mapper.Map<SerialProImageDto>(viewModel));
                var returnData = _mapper.Map<SerialProImageViewModel>(dto);
                return new ResultViewModel<SerialProImageViewModel>(ViewModels.Base.StatusCode.OK, "Done: Serial image has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(SerialProImageViewModel viewModel)
        {
            try
            {
                var dto = await _seProImgService.DeleteSerialProImgAsync(_mapper.Map<SerialProImageDto>(viewModel));
                var returnData = _mapper.Map<SerialProImageViewModel>(dto);
                return new ResultViewModel<SerialProImageViewModel>(ViewModels.Base.StatusCode.OK, "Done: Serial image has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
