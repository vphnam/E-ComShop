using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class ProductDetailDto
    {
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string TypeNo { get; set; }
        public string StyleNo { get; set; }
        public decimal? Price { get; set; }
        public string ProductDescription { get; set; }
        public virtual TypeDto TypeNoNavigation { get; set; }
        public virtual StyleDto StyleNoNavigation { get; set; }
    }
}
