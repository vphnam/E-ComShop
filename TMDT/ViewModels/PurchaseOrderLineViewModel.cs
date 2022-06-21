using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class PurchaseOrderLineViewModel
    {
        public int OrderNo { get; set; }
        public string SerialProductName { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
