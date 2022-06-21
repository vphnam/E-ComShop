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
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _fbService;
        public FeedbackController(IFeedbackService fbService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _fbService = fbService;
        }
        [HttpPost]
        public async Task<object> Add(FeedbackViewModel fbViewModel)
        {
            try
            {
                var fbDto = await _fbService.InsertNewFeedbackAsync(_mapper.Map<FeedbackDto>(fbViewModel));
                var returnData = _mapper.Map<FeedbackViewModel>(fbDto);
                return new ResultViewModel<FeedbackViewModel>(ViewModels.Base.StatusCode.OK, "Done: New feedback has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> UpdateStatus(FeedbackViewModel fbViewModel)
        {
            try
            {
                var fbDto = await _fbService.DeleteFeedbackAsync(_mapper.Map<FeedbackDto>(fbViewModel));
                var returnData = _mapper.Map<FeedbackViewModel>(fbDto);
                return new ResultViewModel<FeedbackViewModel>(ViewModels.Base.StatusCode.OK, "Done: Feedback status has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
