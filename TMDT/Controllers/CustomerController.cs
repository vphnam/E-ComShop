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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _cusService;
        public CustomerController(ICustomerService cusService, IMapper mapper, Helper helper):base(mapper, helper)
        {
            _cusService = cusService;
        }
        [HttpGet]
        public async Task<object> GetList()
        {
            try
            {
                var list = await _cusService.GetAllCustomerAsync();
                var returnData = _mapper.Map<List<CustomerViewModel>>(list);
                return new ResultViewModel<List<CustomerViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get customer list successfully!", returnData);
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
                var cusDto = await _cusService.GetCustomerRecordByNoAsync(no);
                var returnData = _mapper.Map<GetCustomerInfoViewModel>(cusDto);
                return new ResultViewModel<GetCustomerInfoViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get customer with customer no: {0} successfully!", cusDto.CustomerNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetAddress")]
        public async Task<object> GetCustomerAddress(string no)
        {
            try
            {
                var cusDto = await _cusService.GetCustomerRecordByNoAsync(no);
                var returnData = _mapper.Map<GetCustomerInfoViewModel>(cusDto);
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get customer address with customer no: {0} successfully!", cusDto.CustomerNo), returnData.CustomerAddress);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(CustomerViewModel cus)
        {
            try
            {
                cus.CustomerNo = _helper.GenerateId();
                cus.Status = true;
                var cusDto = await _cusService.InsertNewCustomerAsync(_mapper.Map<CustomerDto>(cus));
                var returnData = _mapper.Map<CustomerViewModel>(cusDto);
                return new ResultViewModel<CustomerViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: New customer info has been registered successfully with id {0}!",returnData.CustomerNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(UpdateCustomerViewModel cus)
        {
            cus.Status = true;
            try
            {
                var cusDto = await _cusService.UpdateCustomerAsync(_mapper.Map<UpdateCustomerDto>(cus));
                var returnData = _mapper.Map<CustomerViewModel>(cusDto);
                return new ResultViewModel<CustomerViewModel>(ViewModels.Base.StatusCode.OK, "Done: Customer info has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(CustomerViewModel cus)
        {
            try
            {
                var cusDto = await _cusService.DeleteCustomerAsync(_mapper.Map<CustomerDto>(cus));
                var returnData = _mapper.Map<CustomerViewModel>(cusDto);
                return new ResultViewModel<CustomerViewModel>(ViewModels.Base.StatusCode.OK, "Done: Customer info has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("SearchCustomer")]
        public async Task<object> SearchCustomer(SearchCustomerViewModel search)
        {
            try
            {
                var list = await _cusService.SearchCustomer(search.CustomerNo, search.CustomerName, search.PhoneNumber, search.Email);
                var returnData = _mapper.Map<List<CustomerViewModel>>(list);
                return new ResultViewModel<List<CustomerViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Search employee successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
