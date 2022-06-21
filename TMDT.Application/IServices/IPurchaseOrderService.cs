using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IPurchaseOrderService
    {
        Task<List<PurchaseOrderDto>> GetAllPurchaseOrderAsync();
        Task<PurchaseOrderDto> GetPurchaseOrderRecordByNoAsync(int no);
        Task<object> InsertNewPurchaseOrderAsync(AddPurchaseOrderDto entityDto);
        Task<PurchaseOrderDto> UpdatePurchaseOrderAsync(int no, int code, string note);
        Task<PurchaseOrderDto> CancelPurchaseOrderAsync(int no, bool status);
        Task<List<DashBoardTableDto>> GetDashBoardTable();
        Task<List<PurchaseOrderDto>> GetListByProcessStatus(int code);
        Task<List<PurchaseOrderDto>> GetListByCustomerNo(string no);
        Task<VoucherDto> ApplyVoucher(string customerNo, string voucherNo);
        Task<List<PurchaseOrderDto>> SearchPurchaseOrder(string orderNo, string customerInfo, string employeeInfo, string voucherNo, string orderDate, string status);
    }
}
