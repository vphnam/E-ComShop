using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.Repositories
{
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        public SizeRepository(IConfiguration config):base(config)
        {
        }
        public Task<List<Size>> CheckExistNameAsync(string sizeNo, string sizeName)
        {
            return _dbContext.Sizes.Where(n => n.SizeName == sizeName && n.SizeNo != sizeNo).ToListAsync();
        }
        public async Task<List<Size>> CheckExistByNo(string sizeNo)
        {
            return await _dbContext.Sizes.Where(n => n.SizeNo == sizeNo).ToListAsync();
        }

    }
}
