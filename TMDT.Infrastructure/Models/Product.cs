using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductDescriptions = new HashSet<ProductDescription>();
            SerialProducts = new HashSet<SerialProduct>();
        }

        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string TypeNo { get; set; }
        public string StyleNo { get; set; }
        public decimal? Price { get; set; }
        public string ProductDescription { get; set; }

        public virtual Style StyleNoNavigation { get; set; }
        public virtual Type TypeNoNavigation { get; set; }
        public virtual ICollection<ProductDescription> ProductDescriptions { get; set; }
        public virtual ICollection<SerialProduct> SerialProducts { get; set; }
    }
}
