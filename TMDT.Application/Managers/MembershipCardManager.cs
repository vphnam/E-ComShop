using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Managers
{
    public class MembershipCardManager
    {
        private readonly IMembershipCardRepository _memCardRepo;
        private readonly IMapper _mapper;
        public MembershipCardManager(IMembershipCardRepository memCardRepo, IMapper mapper)
        {
            _memCardRepo = memCardRepo;
            _mapper = mapper;
        }
        public async Task<MembershipCard> AddMembershipCard(MembershipCardDto memCardDto)
        {
            memCardDto.CreatedDate = DateTime.Today;
            memCardDto.RankNo = 1;
            memCardDto.Point = 0;
            memCardDto.Status = true;
            var check = await _memCardRepo.CheckUniqueCustomerNo(memCardDto.CardNo, memCardDto.CustomerNo);
            if (!check.Any())
            {
                return _mapper.Map<MembershipCard>(memCardDto);
            }
            else
            {
                throw new Exception(string.Format("Customer no {0} already have membership card", memCardDto.CustomerNo));
            }
        }
        public async Task<MembershipCard> UpdateMembershipCard(MembershipCardDto memCardDto)
        {
            var check = await _memCardRepo.CheckUniqueCustomerNo(memCardDto.CardNo, memCardDto.CustomerNo);
            if (!check.Any())
            {
                return _mapper.Map<MembershipCard>(memCardDto);
            }
            else
            {
                throw new Exception(string.Format("Customer no {0} already have membership card", memCardDto.CustomerNo));
            }
        }
        public async Task<MembershipCard> DeleteMembershipCard(MembershipCardDto memCardDto)
        {
            memCardDto.Status = false;
            return _mapper.Map<MembershipCard>(memCardDto);
        }
    }
}
