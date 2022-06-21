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
    public class RoleRepository: IRoleRepository 
    {
        private readonly TMDTContext _dbContext;
        public RoleRepository(IConfiguration config)
        {
            _dbContext = new TMDTContext(config);
        }

        public async Task<List<Role>> GetListRole()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetRecordByNo(int? no)
        {
            return await _dbContext.Roles.FindAsync(no);
        }
    }
}
