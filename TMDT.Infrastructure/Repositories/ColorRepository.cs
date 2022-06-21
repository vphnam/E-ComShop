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
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<List<Color>> CheckExistNameAsync(string colorNo, string colorName)
        {
            return await _dbContext.Colors.Where(n => n.ColorName == colorName && n.ColorNo != colorNo).ToListAsync();
        }
        public async Task<List<Color>> CheckExistByNo(string colorNo)
        {
            return await _dbContext.Colors.Where(n => n.ColorNo == colorNo).ToListAsync();
        }
    }
}