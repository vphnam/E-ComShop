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
    public class StyleRepository: Repository<Style>, IStyleRepository
    {
        public StyleRepository(IConfiguration config): base(config)
        {

        }

        public async Task<List<Style>> CheckExistNameAsync(string styleNo, string styleName)
        {
            return await _dbContext.Styles.Where(n => n.StyleName == styleName && n.StyleNo != styleNo).ToListAsync();
        }
        public async Task<List<Style>> CheckExistByNo(string styleNo)
        {
            return await _dbContext.Styles.Where(n => n.StyleNo == styleNo).ToListAsync();
        }
    }
}
