using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class AddPurchaseOrderDto
    {
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string CustomerNo { get; set; }
        public string EmployeeNo { get; set; }
        public string VoucherNo { get; set; }
        public string Note { get; set; }
        public bool SentMail { get; set; }
        public int ProcessStatus { get; set; }
        public bool Status { get; set; }
        public List<AddPurchaseOrderLineDto> ListPurchaseOrderLines { get; set; }
    }
}
