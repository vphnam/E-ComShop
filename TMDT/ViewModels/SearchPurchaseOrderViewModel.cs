using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class SearchPurchaseOrderViewModel
    {
        public string OrderNo { get; set; }
        public string CustomerInfo { get; set; }
        public string EmployeeInfo { get; set; }
        public string VoucherNo { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
    }
}
