using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface IMembershipCardRepository: IRepository<MembershipCard>
    {
        Task<List<MembershipCard>> CheckUniqueCustomerNo(string cardNo, string customerNo);
        Task<List<MembershipCard>> CheckExistCard(string customerNo);
        Task<MembershipCard> GetCardByCustomerNo(string customerNo);
    }
}
