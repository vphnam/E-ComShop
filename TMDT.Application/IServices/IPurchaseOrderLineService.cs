using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IPurchaseOrderLineService
    {
        Task<AddPurchaseOrderLineDto> InsertNewPurchaseOrderLineAsync(AddPurchaseOrderLineDto entityDto);
        Task<List<PurchaseOrderLineDto>> InsertListPurchaseOrderLineAsync(List<PurchaseOrderLineDto> listEntityDto);
        Task<PurchaseOrderLineDto> UpdatePurchaseOrderLineAsync(PurchaseOrderLineDto entityDto);
        Task<PurchaseOrderLineDto> DeletePurchaseOrderLineAsync(PurchaseOrderLineDto entityDto);
        Task<List<PurchaseOrderLineDto>> GetPurchaseOrderLineListByOrderNo(int orderNo);
    }
}
