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
    public class EmployeeController: BaseController
    {
        private readonly IEmployeeService _emService;
        public EmployeeController(IEmployeeService emService, IMapper mapper, Helper helper):base(mapper, helper)
        {
            _emService = emService;
        }
        [HttpGet]
        public async Task<object> GetList()
        {
            try
            {
                var list = await _emService.GetAllEmployeeAsync();
                var returnData = _mapper.Map<List<EmployeeViewModel>>(list);
                return new ResultViewModel<List<EmployeeViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get employee list successfully!", returnData);
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
                var empDto = await _emService.GetEmployeeRecordByNoAsync(no);
                var returnData = _mapper.Map<EmployeeViewModel>(empDto);
                return new ResultViewModel<EmployeeViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get employee with employee no: {0} successfully!", empDto.EmployeeNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(EmployeeChangeViewModel empChange)
        {
            try
            {
                empChange.EmployeeNo = _helper.GenerateId();
                var empDto = await _emService.InsertNewEmployeeAsync(_mapper.Map<EmployeeDto>(empChange));
                var returnData = _mapper.Map<EmployeeChangeViewModel>(empDto);
                return new ResultViewModel<EmployeeChangeViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: New employee info has been created successfully with id {0}!",returnData.EmployeeNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(EmployeeChangeViewModel empChange)
        {
            try
            {
                var empDto = await _emService.UpdateEmployeeAsync(_mapper.Map<EmployeeDto>(empChange));
                var returnData = _mapper.Map<EmployeeChangeViewModel>(empDto);
                return new ResultViewModel<EmployeeChangeViewModel>(ViewModels.Base.StatusCode.OK, "Done: Employee info has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(EmployeeChangeViewModel empChange)
        {
            try
            {
                var empDto = await _emService.DeleteEmployeeAsync(_mapper.Map<EmployeeDto>(empChange));
                var returnData = _mapper.Map<EmployeeChangeViewModel>(empDto);
                return new ResultViewModel<EmployeeChangeViewModel>(ViewModels.Base.StatusCode.OK, "Done: Employee info has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetRoles")]
        public async Task<object> GetListRole()
        {
            try
            {
                var roleDto = await _emService.GetListRoleAsync();
                var returnData = _mapper.Map<List<RoleViewModel>>(roleDto);
                return new ResultViewModel<List<RoleViewModel>>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get role list successfully!"), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("SearchEmployee")]
        public async Task<object> SearchEmployee(SearchEmployeeViewModel search)
        {
            try
            {
                var list = await _emService.SearchEmployee(search.EmployeeNo, search.EmployeeName, search.DateOfBirth, search.PhoneNumber, search.Email);
                var returnData = _mapper.Map<List<EmployeeViewModel>>(list);
                return new ResultViewModel<List<EmployeeViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Search employee successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
