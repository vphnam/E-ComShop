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
    public class PurchaseOrderLineRepository: Repository<PurchaseOrderLine>, IPurchaseOrderLineRepository
    {
        public PurchaseOrderLineRepository(IConfiguration config):base(config)
        {}

        public async Task<List<PurchaseOrderLine>> GetListByOrderNo(int orderNo)
        {
            return await _dbContext.PurchaseOrderLines.Where(n => n.OrderNo == orderNo).ToListAsync();
        }
    }
}
