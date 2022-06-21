using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface IPurchaseOrderLineRepository: IRepository<PurchaseOrderLine>
    {
        Task<List<PurchaseOrderLine>> GetListByOrderNo(int orderNo);
    }
}
