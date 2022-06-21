using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface IPurchaseOrderRepository: IRepository<PurchaseOrder>
    {
        Task<bool> CheckUsedVoucher(string customerNo, string voucherNo);
        Task<PurchaseOrder> GetRecordByIntAsync(int no);
        Task<List<PurchaseOrder>> GetListByCustomerNo(string no);
        Task<int> CountByProcessStatusCode(int code);
        Task<List<PurchaseOrder>> GetListByProcessStatus(int code);
        Task<List<PurchaseOrder>> SearchPurchaseOrder(string orderNo, string customerInfo, string employeeInfo, string voucherNo, string orderDate, string status);
    }
}
