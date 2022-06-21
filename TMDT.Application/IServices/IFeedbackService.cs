using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IFeedbackService
    {
        Task<FeedbackDto> InsertNewFeedbackAsync(FeedbackDto entityDto);
        Task<FeedbackDto> UpdateFeedbackAsync(FeedbackDto entityDto);
        Task<FeedbackDto> DeleteFeedbackAsync(FeedbackDto entityDto);
    }
}
