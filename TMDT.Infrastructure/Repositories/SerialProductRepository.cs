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
    public class SerialProductRepository: Repository<SerialProduct>, ISerialProductRepository 
    {
        public SerialProductRepository(IConfiguration config) : base(config)
        {

        }

        public async Task<List<SerialProduct>> CheckUnique(string serialNo, string productNo, string sizeNo, string colorNo)
        {
            return await _dbContext.SerialProducts.Where(n => n.ProductNo == productNo && n.SizeNo == sizeNo && n.ColorNo == colorNo && n.SerialNo != serialNo).ToListAsync();
        }
    }
}
