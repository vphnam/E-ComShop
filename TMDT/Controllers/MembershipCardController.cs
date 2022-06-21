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
    public class MembershipCardController : BaseController
    {
        private readonly IMembershipCardService _memCardService;
        public MembershipCardController(IMembershipCardService memCardService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _memCardService = memCardService;
        }
        [HttpGet]
        public async Task<object> GetList()
        {
            try
            {
                var list = await _memCardService.GetAllMembershipCardAsync();
                var returnData = _mapper.Map<List<MembershipCardDetailViewModel>>(list);
                return new ResultViewModel<List<MembershipCardDetailViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get membership card list successfully!", returnData);
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
                var cardDto = await _memCardService.GetMembershipCardRecordByNoAsync(no);
                var returnData = _mapper.Map<MembershipCardDetailViewModel>(cardDto);
                return new ResultViewModel<MembershipCardDetailViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get membership card with no: {0} successfully!", cardDto.CardNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("ByCustomerNo")]
        public async Task<object> GetCardByCustomerNo(string no)
        {
            try
            {
                var cardDto = await _memCardService.GetCardByCustomerNo(no);
                var returnData = _mapper.Map<MembershipCardDetailViewModel>(cardDto);
                return new ResultViewModel<MembershipCardDetailViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get membership card with no: {0} successfully!", cardDto.CardNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(AddMembershipCardViewModel card)
        {
            try
            {
                card.CardNo = _helper.GenerateId();
                var cardDto = await _memCardService.InsertNewMembershipCardAsync(_mapper.Map<MembershipCardDto>(card));
                var returnData = _mapper.Map<AddMembershipCardViewModel>(cardDto);
                return new ResultViewModel<AddMembershipCardViewModel>(ViewModels.Base.StatusCode.OK, "Done: New membership card has been registered successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        /*[HttpPost("update")]
        public async Task<object> Update(MembershipCardChangeViewModel card)
        {
            try
            {
                var cardDto = await _memCardService.UpdateMembershipCardAsync(_mapper.Map<MembershipCardDto>(card));
                var returnData = _mapper.Map<MembershipCardChangeViewModel>(cardDto);
                return new ResultViewModel<MembershipCardChangeViewModel>(ViewModels.Base.StatusCode.OK, "Done: Membership card has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }*/
        [HttpPost("delete")]
        public async Task<object> Delete(MembershipCardViewModel card)
        {
            try
            {
                var cardDto = await _memCardService.DeleteMembershipCardAsync(_mapper.Map<MembershipCardDto>(card));
                var returnData = _mapper.Map<MembershipCardViewModel>(cardDto);
                return new ResultViewModel<MembershipCardViewModel>(ViewModels.Base.StatusCode.OK, "Done: Membership card has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
