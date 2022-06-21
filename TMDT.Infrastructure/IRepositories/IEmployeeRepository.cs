using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<List<Employee>> CheckUniquePhoneNumber(string employeeNo, string phoneNumber);
        Task<List<Employee>> CheckUniqueEmail(string employeeNo, string email);
        Task<List<Employee>> SearchEmployee(string empNo, string empName, string dateOfBirth, string phoneNumber, string email);
        Task<Employee> GetEmployeeCredential(string email, string passWord);
    }
}
