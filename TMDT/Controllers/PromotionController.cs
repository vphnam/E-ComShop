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
    public class PromotionController : BaseController
    {
        private readonly IPromotionService _proService;
        public PromotionController(IPromotionService proService, IMapper mapper, Helper helper):base(mapper, helper)
        {
            _proService = proService;
        }
        [HttpGet]
        public async Task<object> GetList()
        {
            try
            {
                var list = await _proService.GetAllPromotionAsync();
                var returnData = _mapper.Map<List<PromotionViewModel>>(list);
                return new ResultViewModel<List<PromotionViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get promotion list successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetByNo")]
        public async Task<object> GetByNo(string no)
        {
            try
            {
                var promotionDto = await _proService.GetPromotionRecordByNoAsync(no);
                var returnData = _mapper.Map<PromotionViewModel>(promotionDto);
                return new ResultViewModel<PromotionViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with promotion no: {0} successfully", no), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(PromotionViewModel proViewModel)
        {
            try
            {
                proViewModel.PromotionNo = _helper.GenerateId();
                var promotionDto = await _proService.InsertNewPromotionAsync(_mapper.Map<PromotionDto>(proViewModel));
                var returnData = _mapper.Map<PromotionViewModel>(promotionDto);
                return new ResultViewModel<PromotionViewModel>(ViewModels.Base.StatusCode.OK, "Done: New promotion has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(PromotionViewModel proViewModel)
        {
            try
            {
                var promotionDto = await _proService.UpdatePromotionAsync(_mapper.Map<PromotionDto>(proViewModel));
                var returnData = _mapper.Map<PromotionViewModel>(promotionDto);
                return new ResultViewModel<PromotionViewModel>(ViewModels.Base.StatusCode.OK, "Done: Promotion has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(PromotionViewModel proViewModel)
        {
            try
            {
                var promotionDto = await _proService.DeletePromotionAsync(_mapper.Map<PromotionDto>(proViewModel));
                var returnData = _mapper.Map<PromotionViewModel>(promotionDto);
                return new ResultViewModel<PromotionViewModel>(ViewModels.Base.StatusCode.OK, "Done: Promotion has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
