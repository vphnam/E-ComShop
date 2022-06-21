using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Shared.Dto;

namespace TMDT.Application.IServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployeeAsync();
        Task<EmployeeDto> GetEmployeeRecordByNoAsync(string no);
        Task<EmployeeDto> InsertNewEmployeeAsync(EmployeeDto entityDto);
        Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto entityDto);
        Task<EmployeeDto> DeleteEmployeeAsync(EmployeeDto entityDto);
        Task<List<RoleDto>> GetListRoleAsync();
        Task<List<EmployeeDto>> SearchEmployee(string empNo, string empName, string dateOfBirth, string phoneNumber, string email);
        Task<EmployeeDto> GetEmployeeCredential(string email, string passWord);
    }
}
