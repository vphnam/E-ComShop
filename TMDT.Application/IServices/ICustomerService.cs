using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomerAsync();
        Task<CustomerDto> GetCustomerRecordByNoAsync(string no);
        Task<CustomerDto> InsertNewCustomerAsync(CustomerDto entityDto);
        Task<UpdateCustomerDto> UpdateCustomerAsync(UpdateCustomerDto entityDto);
        Task<CustomerDto> DeleteCustomerAsync(CustomerDto entityDto);
        Task<List<CustomerDto>> SearchCustomer(string cusNo, string cusName, string phoneNumber, string email);
        Task<CustomerDto> GetCustomerCredential(string email, string passWord);
    }
}
