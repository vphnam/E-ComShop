using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Application.Managers;
using TMDT.Infrastructure.IRepositories;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class MembershipCardService: Service, IMembershipCardService
    {
        private readonly IMembershipCardRepository _memCardRepo;
        private readonly ICustomerRepository _cusRepo;
        private readonly ICardRankRepository _cardRankRepo;
        private readonly MembershipCardManager _memCardManager;
        public MembershipCardService(IMembershipCardRepository memCardRepo, ICustomerRepository cusRepo, ICardRankRepository cardRankRepo, 
            MembershipCardManager memCardManager, IMapper mapper):base(mapper)
        {
            _memCardRepo = memCardRepo;
            _cusRepo = cusRepo;
            _cardRankRepo = cardRankRepo;
            _memCardManager = memCardManager;
        }

        public async Task<List<MembershipCardDto>> GetAllMembershipCardAsync()
        {
            var list = await _memCardRepo.GetCanChangeListAllAsync();
            foreach(var item in list)
            {
                item.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(item.CustomerNo);
                item.RankNoNavigation = await _cardRankRepo.GetRecordByNo(item.RankNo);
            }
            return _mapper.Map<List<MembershipCardDto>>(list);
        }

        public async Task<MembershipCardDto> GetMembershipCardRecordByNoAsync(string no)
        {
            var memCard = await _memCardRepo.GetRecordByNoAsync(no);
            if (memCard != null)
            {
                memCard.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(memCard.CustomerNo);
                memCard.RankNoNavigation = await _cardRankRepo.GetRecordByNo(memCard.RankNo);
                return _mapper.Map<MembershipCardDto>(memCard);
            }
            else
                throw new Exception(string.Format("Membership card no {0} not found", no));
        }

        public async Task<MembershipCardDto> InsertNewMembershipCardAsync(MembershipCardDto entityDto)
        {
            var memCard = await _memCardManager.AddMembershipCard(entityDto);
            var dto = _mapper.Map<MembershipCardDto>(await _memCardRepo.InsertNewAsync(memCard));
            return dto;
        }

        public async Task<MembershipCardDto> UpdateMembershipCardAsync(MembershipCardDto entityDto)
        {
            var memCard = await _memCardManager.UpdateMembershipCard(entityDto);
            var dto = _mapper.Map<MembershipCardDto>(await _memCardRepo.UpdateAsync(memCard));
            return dto;
        }

        public async Task<MembershipCardDto> DeleteMembershipCardAsync(MembershipCardDto entityDto)
        {
            var memCard = await _memCardManager.DeleteMembershipCard(entityDto);
            var dto = _mapper.Map<MembershipCardDto>(await _memCardRepo.DeleteAsync(memCard));
            return dto;
        }

        public async Task<MembershipCardDto> GetCardByCustomerNo(string no)
        {
            var memCard = await _memCardRepo.GetCardByCustomerNo(no);
            if (memCard != null)
            {
                memCard.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(memCard.CustomerNo);
                memCard.RankNoNavigation = await _cardRankRepo.GetRecordByNo(memCard.RankNo);
                return _mapper.Map<MembershipCardDto>(memCard);
            }
            else
                throw new Exception(string.Format("Membership card no {0} not found", no));
        }
    }
}
