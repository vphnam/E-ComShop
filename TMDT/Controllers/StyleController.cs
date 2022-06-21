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
    public class StyleController : BaseController
    {
        private readonly IStyleService _styleService;
        public StyleController(IStyleService styleService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _styleService = styleService;
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var styleDtoList = await _styleService.GetAllStyleAsync();
                var returnData = _mapper.Map<List<StyleViewModel>>(styleDtoList);
                return new ResultViewModel<List<StyleViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get style list successfully!", returnData);
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
                var styleDto = await _styleService.GetStyleRecordByNoAsync(no);
                var returnData = _mapper.Map<StyleViewModel>(styleDto);
                return new ResultViewModel<StyleViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with style no: {0} successfully", no), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(StyleViewModel style)
        {
            try
            {
                style.StyleNo = "1";
                var styleDto = await _styleService.InsertNewStyleAsync(_mapper.Map<StyleDto>(style));
                var returnData = _mapper.Map<StyleViewModel>(styleDto);
                return new ResultViewModel<StyleViewModel>(ViewModels.Base.StatusCode.OK, "Done: New style has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(StyleViewModel style)
        {
            try
            {
                var styleDto = await _styleService.UpdateStyleAsync(_mapper.Map<StyleDto>(style));
                var returnData = _mapper.Map<StyleViewModel>(styleDto);
                return new ResultViewModel<StyleViewModel>(ViewModels.Base.StatusCode.OK, "Done: Color has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(StyleViewModel style)
        {
            try
            {
                var styleDto = await _styleService.DeleteStyleAsync(_mapper.Map<StyleDto>(style));
                var returnData = _mapper.Map<StyleViewModel>(styleDto);
                return new ResultViewModel<StyleViewModel>(ViewModels.Base.StatusCode.OK, "Done: Color has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
