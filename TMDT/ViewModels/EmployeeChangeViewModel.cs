using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class EmployeeChangeViewModel
    {
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int? RoleNo { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool? Status { get; set; }
    }
}
