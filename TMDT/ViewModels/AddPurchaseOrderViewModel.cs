using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class AddPurchaseOrderViewModel
    {
        public int OrderNo { get; set; }
        public string DeliveryAddress { get; set; }
        public string CustomerNo { get; set; }
        public string EmployeeNo { get; set; }
        public string VoucherNo { get; set; }
        public string Note { get; set; }
        public List<PurchaseOrderLineViewModel> ListPurchaseOrderLines { get; set; }
    }
}
