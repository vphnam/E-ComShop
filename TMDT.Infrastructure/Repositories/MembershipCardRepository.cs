using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.Repositories
{
    public class MembershipCardRepository: Repository<MembershipCard>, IMembershipCardRepository 
    {
        public MembershipCardRepository(IConfiguration config): base(config)
        {

        }

        public async Task<List<MembershipCard>> CheckExistCard(string customerNo)
        {
            return await _dbContext.MembershipCards.Where(n => n.CustomerNo == customerNo).ToListAsync();
        }

        public async Task<List<MembershipCard>> CheckUniqueCustomerNo(string cardNo, string customerNo)
        {
            return await _dbContext.MembershipCards.Where(n => n.CustomerNo == customerNo && n.CardNo != cardNo).ToListAsync();
        }

        public async Task<MembershipCard> GetCardByCustomerNo(string customerNo)
        {
            return await _dbContext.MembershipCards.Where(n => n.CustomerNo == customerNo).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
