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
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(IConfiguration config): base(config)
        {

        }

        public async Task<List<Product>> CheckExistNameAsync(string productNo, string productName)
        {
            return await _dbContext.Products.Where(n => n.ProductName == productName && n.ProductNo != productNo).ToListAsync();
        }
    }
}
