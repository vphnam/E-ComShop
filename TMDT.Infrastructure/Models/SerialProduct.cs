using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class SerialProduct
    {
        public SerialProduct()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            SerialProImages = new HashSet<SerialProImage>();
        }

        public string SerialNo { get; set; }
        public string ProductNo { get; set; }
        public string SizeNo { get; set; }
        public string ColorNo { get; set; }
        public string PromotionNo { get; set; }
        public string ProductDetailImage { get; set; }
        public string ProductDetailDescription { get; set; }
        public int Quantity { get; set; }

        public virtual Color ColorNoNavigation { get; set; }
        public virtual Product ProductNoNavigation { get; set; }
        public virtual Promotion PromotionNoNavigation { get; set; }
        public virtual Size SizeNoNavigation { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<SerialProImage> SerialProImages { get; set; }
    }
}
