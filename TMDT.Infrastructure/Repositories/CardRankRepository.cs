using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.Repositories
{
    public class CardRankRepository : ICardRankRepository
    {
        private readonly TMDTContext _dbContext;
        public CardRankRepository(IConfiguration config)
        {
            _dbContext = new TMDTContext(config);
        }
        public async Task<CardRank> GetRecordByNo(int no)
        {
            return await _dbContext.CardRanks.FindAsync(no);
        }
    }
}
