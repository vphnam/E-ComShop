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
    public class VoucherRepository: Repository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(IConfiguration config):base(config)
        {

        }

        public async Task<List<Voucher>> CheckUniqueName(string voucherNo, string voucherName)
        {
            return await _dbContext.Vouchers.Where(n => n.VoucherName == voucherName && n.VoucherNo != voucherNo).ToListAsync();
        }
    }
}
