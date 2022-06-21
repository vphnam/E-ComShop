using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class EmployeeViewModel
    {
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int? RoleNo { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool? Status { get; set; }
        public virtual RoleViewModel RoleNoNavigation { get; set; }

        /*
        public EmployeeViewModel(string employeeNo, string employeeName, DateTime? dateofBirth, string phoneNumber, int? roleNo, string email, string passWord, bool? status,string roleName)
        {
            this.EmployeeNo = employeeNo;
            this.EmployeeName = employeeName;
            this.DateOfBirth = dateofBirth;
            this.PhoneNumber = phoneNumber;
            this.RoleNo = roleNo;
            this.RoleName = roleName;
            this.Email = email;
            this.PassWord = passWord;
            this.Status = status;
        }*/
    }
}
