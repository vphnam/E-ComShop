using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<List<Customer>> CheckUniquePhoneNumber(string customerNo, string phoneNumber);
        Task<List<Customer>> CheckUniqueEmail(string customerNo, string email);
        Task<List<Customer>> GetRecordByNo(string customerNo);
        Task<List<Customer>> SearchCustomer(string cusNo, string cusName, string phoneNumber, string email);
        Task<List<Customer>> CheckOldPassWord(string cusNo, string passWord);
        Task<Customer> GetCustomerCredential(string email, string passWord);
    }
}
