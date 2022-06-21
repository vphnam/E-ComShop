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
    public class SerialProductController : BaseController
    {
        private readonly ISerialProductService _serialProService;
        public SerialProductController(ISerialProductService serialProService, IMapper mapper, Helper helper):base(mapper,helper)
        {
            _serialProService = serialProService;
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var returnData = await _serialProService.GetAllSerialProductAsync();
                return new ResultViewModel<List<DisplayProductDto>>(ViewModels.Base.StatusCode.OK, "Done: Get serial product list successfully!", returnData);
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
                var returnData = await _serialProService.GetSerialProductRecordByNoAsync(no);
                return new ResultViewModel<DisplaySingleProduct>(ViewModels.Base.StatusCode.OK, "Done: Get serial product list successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(SerialProductChangeViewModel sPro)
        {
            try
            {
                sPro.SerialNo = _helper.GenerateId();
                var sProDto = await _serialProService.InsertNewSerialProductAsync(_mapper.Map<SerialProductDto>(sPro));
                var returnData = _mapper.Map<SerialProductChangeViewModel>(sProDto);
                return new ResultViewModel<SerialProductChangeViewModel>(ViewModels.Base.StatusCode.OK, "Done: New serial product has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(SerialProductChangeViewModel sPro)
        {
            try
            {
                var sProDto = await _serialProService.UpdateSerialProductAsync(_mapper.Map<SerialProductDto>(sPro));
                var returnData = _mapper.Map<SerialProductViewModel>(sProDto);
                return new ResultViewModel<SerialProductViewModel>(ViewModels.Base.StatusCode.OK, "Done: Serial product has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(SerialProductChangeViewModel sPro)
        {
            try
            {
                var sProDto = await _serialProService.DeleteSerialProductAsync(_mapper.Map<SerialProductDto>(sPro));
                var returnData = _mapper.Map<SerialProductViewModel>(sProDto);
                return new ResultViewModel<SerialProductViewModel>(ViewModels.Base.StatusCode.OK, "Done: Serial product has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
