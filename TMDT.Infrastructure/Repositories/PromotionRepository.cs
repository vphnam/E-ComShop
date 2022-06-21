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
    public class PromotionRepository: Repository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(IConfiguration config):base(config)
        {}

        public async Task<List<Promotion>> CheckExistNameAsync(string promotionNo, string promotionName)
        {
            return await _dbContext.Promotions.Where(n => n.PromotionName == promotionName && n.PromotionNo != promotionNo).ToListAsync();
        }
    }
}
