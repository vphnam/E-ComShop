using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class SerialProductDto
    {
        public string SerialNo { get; set; }
        public string ProductNo { get; set; }
        public string SizeNo { get; set; }
        public string ColorNo { get; set; }
        public string PromotionNo { get; set; }
        public string ProductDetailImage { get; set; }
        public string ProductDetailDescription { get; set; }
        public int Quantity { get; set; }

        public virtual ColorDto ColorNoNavigation { get; set; }
        public virtual ProductDetailDto ProductNoNavigation { get; set; }
        public virtual PromotionDto PromotionNoNavigation { get; set; }
        public virtual SizeDto SizeNoNavigation { get; set; }
    }
}
