using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class PurchaseOrderLineDto
    {
        public int OrderNo { get; set; }
        public string SerialProductName { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal BuyPrice { get; set; }
        public PurchaseOrderLineDto()
        {

        }
        public PurchaseOrderLineDto(int orderNo, string serialProductName, int quantityOrdered, decimal buyPrice)
        {
            this.OrderNo = orderNo;
            this.SerialProductName = serialProductName;
            this.QuantityOrdered = quantityOrdered;
            this.BuyPrice = buyPrice;
        }
    }
}
