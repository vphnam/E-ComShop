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
    public class TypeController : BaseController
    {
        private readonly ITypeService _typeService;
        public TypeController(ITypeService typeService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _typeService = typeService;
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var typeDtoList = await _typeService.GetAllTypeAsync();
                var returnData = _mapper.Map<List<TypeViewModel>>(typeDtoList);
                return new ResultViewModel<List<TypeViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get type list successfully!", returnData);
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
                var typeDto = await _typeService.GetTypeRecordByNoAsync(no);
                var returnData = _mapper.Map<TypeViewModel>(typeDto);
                return new ResultViewModel<TypeViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with type no: {0} successfully", no), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(TypeViewModel type)
        {
            try
            {
                type.TypeNo = "1";
                var typeDto = await _typeService.InsertNewTypeAsync(_mapper.Map<TypeDto>(type));
                var returnData = _mapper.Map<TypeDto>(typeDto);
                return new ResultViewModel<TypeDto>(ViewModels.Base.StatusCode.OK, "Done: New type has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(TypeViewModel type)
        {
            try
            {
                var typeDto = await _typeService.UpdateTypeAsync(_mapper.Map<TypeDto>(type));
                var returnData = _mapper.Map<TypeViewModel>(typeDto);
                return new ResultViewModel<TypeViewModel>(ViewModels.Base.StatusCode.OK, "Done: Type has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(TypeViewModel type)
        {
            try
            {
                var typeDto = await _typeService.DeleteTypeAsync(_mapper.Map<TypeDto>(type));
                var returnData = _mapper.Map<TypeViewModel>(typeDto);
                return new ResultViewModel<TypeViewModel>(ViewModels.Base.StatusCode.OK, "Done: Size has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
