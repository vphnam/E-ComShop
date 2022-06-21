using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.IRepositories;

namespace TMDT.Infrastructure.Repositories
{
    public class TypeRepository : Repository<Models.Type>, ITypeRepository
    {
        public TypeRepository(IConfiguration config):base(config)
        {

        }

        public async Task<List<Models.Type>> CheckExistNameAsync(string typeNo, string typeName)
        {
            return await _dbContext.Types.Where(n => n.TypeName == typeName && n.TypeNo != typeNo).ToListAsync();
        }
        public async Task<List<Models.Type>> CheckExistByNo(string typeNo)
        {
            return await _dbContext.Types.Where(n => n.TypeNo == typeNo).ToListAsync();
        }
    }
}
