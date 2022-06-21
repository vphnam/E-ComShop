﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class ClientCredential
    {
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool TypeUser { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
    }
}
