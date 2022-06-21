﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class UpdateCustomerViewModel
    {
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OldPassWord { get; set; }
        public string PassWord { get; set; }
        public bool? Status { get; set; }
    }
}
