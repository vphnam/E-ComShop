using AutoMapper;
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
    public class ColorController: BaseController
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _colorService = colorService;
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var colorDtoList = await _colorService.GetAllColorAsync();
                var returnData = _mapper.Map<List<ColorViewModel>>(colorDtoList);
                return new ResultViewModel<List<ColorViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get color list successfully!", returnData);
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
                var colorDto = await _colorService.GetColorRecordByNoAsync(no);
                var returnData = _mapper.Map<ColorViewModel>(colorDto);
                return new ResultViewModel<ColorViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with color no: {0} successfully", no), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(ColorViewModel color)
        {
            try
            {
                color.ColorNo = "1";
                var colorDto = await _colorService.InsertNewColorAsync(_mapper.Map<ColorDto>(color));
                var returnData = _mapper.Map<ColorViewModel>(colorDto);
                return new ResultViewModel<ColorViewModel>(ViewModels.Base.StatusCode.OK, "Done: New color has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(ColorViewModel color)
        {
            try
            {
                var colorDto = await _colorService.UpdateColorAsync(_mapper.Map<ColorDto>(color));
                var returnData = _mapper.Map<ColorViewModel>(colorDto);
                return new ResultViewModel<ColorViewModel>(ViewModels.Base.StatusCode.OK, "Done: Color has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(ColorViewModel color)
        {
            try
            {
                var colorDto = await _colorService.DeleteColorAsync(_mapper.Map<ColorDto>(color));
                var returnData = _mapper.Map<ColorViewModel>(colorDto);
                return new ResultViewModel<ColorViewModel>(ViewModels.Base.StatusCode.OK, "Done: Color has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
