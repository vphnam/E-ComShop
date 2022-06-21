using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class SerialProductChangeViewModel
    {
        public string SerialNo { get; set; }
        public string ProductNo { get; set; }
        public string SizeNo { get; set; }
        public string ColorNo { get; set; }
        public string PromotionNo { get; set; }
        public string ProductDetailImage { get; set; }
        public string ProductDetailDescription { get; set; }
        public int Quantity { get; set; }
    }
}
