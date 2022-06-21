using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class DisplaySingleProduct
    {
        public DisplaySingleProduct(string serialNo, string productNo, string title, string image, decimal price, string shortDesc, string color, PromotionDto promo, int quantity, IEnumerable<string> listImage)
        {
            this.SerialNo = serialNo;
            this.ProductNo = productNo;
            this.Title = title;
            this.Image = image;
            this.Price = price;
            this.ShortDesc = shortDesc;
            this.Color = color;
            this.Promotion = promo;
            this.Quantity = quantity;
            this.ListImage = listImage ;
        }
        public string SerialNo { get; set; }
        public string ProductNo { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string ShortDesc { get; set; }
        public string Color { get; set; }
        public PromotionDto Promotion { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<string> ListImage { get; set; }
    }
}
