﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class ProductViewModel
    {
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string TypeNo { get; set; }
        public string StyleNo { get; set; }
        public decimal? Price { get; set; }
        public string ProductDescription { get; set; }
    }
}
