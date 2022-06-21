using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IMembershipCardService
    {
        Task<List<MembershipCardDto>> GetAllMembershipCardAsync();
        Task<MembershipCardDto> GetMembershipCardRecordByNoAsync(string no);
        Task<MembershipCardDto> InsertNewMembershipCardAsync(MembershipCardDto entityDto);
        Task<MembershipCardDto> UpdateMembershipCardAsync(MembershipCardDto entityDto);
        Task<MembershipCardDto> DeleteMembershipCardAsync(MembershipCardDto entityDto);
        Task<MembershipCardDto> GetCardByCustomerNo(string no);
    }
}
