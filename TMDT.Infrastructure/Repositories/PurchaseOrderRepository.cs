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
    public class PurchaseOrderRepository: Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(IConfiguration config):base(config)
        { }
        public async Task<PurchaseOrder> GetRecordByIntAsync(int no)
        {
            return await _dbContext.PurchaseOrders.FindAsync(no);
        }
        public async Task<bool> CheckUsedVoucher(string customerNo, string voucherNo)
        {
            if (voucherNo != null)
                return await _dbContext.PurchaseOrders.Where(n => n.VoucherNo == voucherNo && n.CustomerNo == customerNo).AsNoTracking().AnyAsync();
            else
                return false;
        }

        public async Task<int> CountByProcessStatusCode(int code)
        {
            return await _dbContext.PurchaseOrders.Where(n => n.ProcessStatus == code).CountAsync();
        }

        public async Task<List<PurchaseOrder>> GetListByProcessStatus(int code)
        {
            return await _dbContext.PurchaseOrders.Where(n => n.ProcessStatus == code).AsNoTracking().ToListAsync();
        }

        public async Task<List<PurchaseOrder>> SearchPurchaseOrder(string orderNo, string customerInfo, string employeeInfo, string voucherNo, string orderDate, string status)
        {
            List<PurchaseOrder> poList = new List<PurchaseOrder>();
            if (orderNo != "")
            {
                poList = await _dbContext.PurchaseOrders.Where(n => n.OrderNo.ToString().Contains(orderNo) && n.CustomerNo.Contains(customerInfo) 
                && n.EmployeeNo.Contains(employeeInfo) && n.VoucherNo.Contains(voucherNo)).ToListAsync();
            }
            if (orderDate != "")
            {
                DateTime date = (Convert.ToDateTime(orderDate));
                if (poList.Count > 0)
                    poList = poList.Where(n => n.OrderDate.Day == date.Day && n.OrderDate.Month == date.Month && n.OrderDate.Year == date.Year).ToList();
                else
                    poList = await _dbContext.PurchaseOrders.Where(n => n.OrderDate.Day == date.Day && n.OrderDate.Month == date.Month && n.OrderDate.Year == date.Year).ToListAsync();
            }
            if (status != "")
            {
                bool flag;
                if (status == "Y")
                    flag = true;
                else
                    flag = false;
                if (poList.Count > 0)
                    poList = poList.Where(n => n.Status == flag).ToList();
                else
                    poList = await _dbContext.PurchaseOrders.Where(n => n.Status == flag).ToListAsync();
            }

            return poList;
        }

        public async Task<List<PurchaseOrder>> GetListByCustomerNo(string no)
        {
            return await _dbContext.PurchaseOrders.Where(n => n.CustomerNo == no).OrderByDescending(n => n.OrderDate).AsNoTracking().ToListAsync();
        }
    }
}