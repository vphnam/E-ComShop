using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class FeedbackService: Service, IFeedbackService
    {
        private readonly IFeedbackRepository _fbRepo;
        public FeedbackService(IFeedbackRepository fbRepo, IMapper mapper):base(mapper)
        {
            _fbRepo = fbRepo;
        }

        public async Task<FeedbackDto> InsertNewFeedbackAsync(FeedbackDto entityDto)
        {
            var fb = await _fbRepo.InsertNewAsync(_mapper.Map<Feedback>(entityDto));
            return _mapper.Map<FeedbackDto>(fb);
        }

        public async Task<FeedbackDto> UpdateFeedbackAsync(FeedbackDto entityDto)
        {
            var fb = await _fbRepo.UpdateAsync(_mapper.Map<Feedback>(entityDto));
            return _mapper.Map<FeedbackDto>(fb);
        }

        public async Task<FeedbackDto> DeleteFeedbackAsync(FeedbackDto entityDto)
        {
            entityDto.Status = false;
            var fb = await _fbRepo.UpdateAsync(_mapper.Map<Feedback>(entityDto));
            return _mapper.Map<FeedbackDto>(fb);
        }
    }
}
