using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class SerialProductViewModel
    {
        public string SerialNo { get; set; }
        public string ProductNo { get; set; }
        public string SizeNo { get; set; }
        public string ColorNo { get; set; }
        public string PromotionNo { get; set; }
        public string ProductDetailImage { get; set; }
        public string ProductDetailDescription { get; set; }

        public virtual ColorViewModel ColorNoNavigation { get; set; }
        public virtual ProductDetailViewModel ProductNoNavigation { get; set; }
        public virtual PromotionViewModel PromotionNoNavigation { get; set; }
        public virtual SizeViewModel SizeNoNavigation { get; set; }
    }
}
