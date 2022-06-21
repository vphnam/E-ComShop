using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class PurchaseOrderListViewModel
    {
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string VoucherNo { get; set; }
        public bool SentMail { get; set; }
        public string ProcessStatus { get; set; }
        public double InTheProcessDay { get; set; }
        public string Status { get; set; }
    }
}
