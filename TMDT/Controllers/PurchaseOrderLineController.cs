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
    public class PurchaseOrderLineController : BaseController
    {
        private readonly IPurchaseOrderLineService _polService;
        public PurchaseOrderLineController(IPurchaseOrderLineService polService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _polService = polService;
        }
        [HttpPost]
        public async Task<object> Add(AddPurchaseOrderLineViewModel polViewModel)
        {
            try
            {
                var polDto = await _polService.InsertNewPurchaseOrderLineAsync(_mapper.Map<AddPurchaseOrderLineDto>(polViewModel));
                var returnData = _mapper.Map<AddPurchaseOrderLineViewModel>(polDto);
                return new ResultViewModel<AddPurchaseOrderLineViewModel>(ViewModels.Base.StatusCode.OK, "Done: New purchase order line has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetByOrderNo")]
        public async Task<object> GetByOrderNo(int no)
        {
            try
            {
                var polDtoList = await _polService.GetPurchaseOrderLineListByOrderNo(no);
                var returnData = _mapper.Map<List<PurchaseOrderLineViewModel>>(polDtoList);
                return new ResultViewModel<List<PurchaseOrderLineViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get purchase order line by order no successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
