using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class Employee
    {
        public Employee()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int? RoleNo { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool? Status { get; set; }

        public virtual Role RoleNoNavigation { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
