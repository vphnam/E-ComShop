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
    public class FeedbackRepository: Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IConfiguration config):base(config)
        {

        }

        public async Task<List<Feedback>> GetListByOrderNo(int no)
        {
            return await _dbContext.Feedbacks.Where(n => n.OrderNo == no).ToListAsync();
        }
    }
}
