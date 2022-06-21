using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class PromotionDto
    {
        public string PromotionNo { get; set; }
        public string PromotionName { get; set; }
        public double? SalePercent { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
    }
}
