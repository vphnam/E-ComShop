using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class UpdatePurchaseOrderViewModel
    {
        public int OrderNo { get; set; }
        public int ProcessStatusCode { get; set; }
        public string Note { get; set; }
    }
}
