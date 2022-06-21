using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class PurchaseOrderController : BaseController
    {
        private readonly IPurchaseOrderService _poService;
        private readonly IPurchaseOrderLineService _polService;
        public PurchaseOrderController(IPurchaseOrderService poService, IPurchaseOrderLineService polService, IMapper mapper, Helper helper):base(mapper,helper)
        {
            _poService = poService;
            _polService = polService;
        }

        [HttpGet]
        public async Task<object> GetList()
        {
            try
            {
                var list = await _poService.GetAllPurchaseOrderAsync();
                var returnData = _mapper.Map<List<PurchaseOrderListViewModel>>(list);
                return new ResultViewModel<List<PurchaseOrderListViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get purchase order list successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("ByCustomerNo")]
        public async Task<object> GetListByCustomerNo(string no)
        {
            try
            {
                var list = await _poService.GetListByCustomerNo(no);
                var returnData = _mapper.Map<List<PurchaseOrderListViewModel>>(list);
                return new ResultViewModel<List<PurchaseOrderListViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get purchase order list successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetDashBoardTable")]
        public async Task<object> GetDashBoard()
        {
            try
            {
                var list = await _poService.GetDashBoardTable();
                var returnData = _mapper.Map<List<DashBoardTableViewModel>>(list);
                return new ResultViewModel<List<DashBoardTableViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get purchase order dashboard successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetByNo")]
        public async Task<object> GetByNo(int no)
        {
            try
            {
                var poDto = await _poService.GetPurchaseOrderRecordByNoAsync(no);
                var returnData = _mapper.Map<PurchaseOrderDetailViewModel>(poDto);
                return new ResultViewModel<PurchaseOrderDetailViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with purchase order no: {0} successfully", no), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("ApplyVoucher")]
        public async Task<object> ApplyVoucher(string customerNo, string voucherNo)
        {
            try
            {
                var returnData = await _poService.ApplyVoucher(customerNo, voucherNo);
                return new ResultViewModel<VoucherDto>(ViewModels.Base.StatusCode.OK, string.Format("Done: Apply voucher successfully {0}", voucherNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetByProcessStatus")]
        public async Task<object> GetByProcessStatus(int code)
        {
            try
            {
                var list = await _poService.GetListByProcessStatus(code);
                var returnData = _mapper.Map<List<PurchaseOrderListViewModel>>(list);
                return new ResultViewModel<List<PurchaseOrderListViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get purchase order list by process status successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetProcessList")]
        public object GetProcessList()
        {
            var returnData = new List<DashBoardTableDto>()
            {
                new DashBoardTableDto(0,"Failed"),
                new DashBoardTableDto(1,"Received"),
                new DashBoardTableDto(2,"Processing"),
                new DashBoardTableDto(3,"Confirmed"),
                new DashBoardTableDto(4,"Arrived at shipping partner"),
                new DashBoardTableDto(5,"Delivered"),
                new DashBoardTableDto(6,"Waiting to complete"),
                new DashBoardTableDto(7,"Return and refund"),
                new DashBoardTableDto(8,"Done"),
            };
            return new ResultViewModel<List<DashBoardTableDto>>(ViewModels.Base.StatusCode.OK, "Done: Process status list successfully!", returnData);
        }
        [HttpPost("SearchPurchaseOrder")]
        public async Task<object> SearchPurchaseOrder(SearchPurchaseOrderViewModel search)
        {
            try
            {
                var list = await _poService.SearchPurchaseOrder(search.OrderNo, search.CustomerInfo, search.EmployeeInfo, search.VoucherNo, search.OrderDate, search.Status);
                var returnData = _mapper.Map<List<PurchaseOrderListViewModel>>(list);
                return new ResultViewModel<List<PurchaseOrderListViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Search purchase order successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(AddPurchaseOrderDto poViewModel)
        {
            try
            {
                var returnData = await _poService.InsertNewPurchaseOrderAsync(poViewModel);
               //poDto.PurchaseOrderLines = await _polService.InsertListPurchaseOrderLineAsync(_mapper.Map<List<PurchaseOrderLineDto>>(poViewModel.PurchaseOrderLines));
                return new ResultViewModel<object>(ViewModels.Base.StatusCode.OK, "Done: New purchase order has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(UpdatePurchaseOrderViewModel poViewModel)
        {
            try
            {
                var poDto = await _poService.UpdatePurchaseOrderAsync(poViewModel.OrderNo, poViewModel.ProcessStatusCode, poViewModel.Note);  
                var returnData = _mapper.Map<PurchaseOrderDetailViewModel>(poDto);
                return new ResultViewModel<PurchaseOrderDetailViewModel>(ViewModels.Base.StatusCode.OK, "Done: Purchase order has been changes successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("cancel")]
        public async Task<object> Cancel(CancelPurchaseOrderViewModel poViewModel)
        {
            try
            {
                var poDto = await _poService.CancelPurchaseOrderAsync(poViewModel.OrderNo, poViewModel.Status);
                var returnData = _mapper.Map<PurchaseOrderDetailViewModel>(poDto);
                return new ResultViewModel<PurchaseOrderDetailViewModel>(ViewModels.Base.StatusCode.OK, "Done: Purchase order has been cancelled successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
