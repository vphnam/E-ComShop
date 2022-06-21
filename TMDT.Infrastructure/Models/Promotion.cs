using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            SerialProducts = new HashSet<SerialProduct>();
        }

        public string PromotionNo { get; set; }
        public string PromotionName { get; set; }
        public double? SalePercent { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<SerialProduct> SerialProducts { get; set; }
    }
}
