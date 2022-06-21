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
    public class ProductDescriptionRepository : Repository<ProductDescription>, IProductDescriptionRepository
    {
        public ProductDescriptionRepository(IConfiguration config): base(config)
        {

        }

        public async Task<IReadOnlyList<ProductDescription>> GetListByProductNoAsync(string productNo)
        {
            return await _dbContext.ProductDescriptions.Where(n => n.ProductNo == productNo).ToListAsync();
        }

        public async Task<ProductDescription> GetRecordByNoAsync(string productDescriptionNo, string productNo)
        {
            return await _dbContext.ProductDescriptions.FindAsync(productDescriptionNo, productNo);
        }
    }
}
