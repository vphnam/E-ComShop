using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Application.Managers;
using TMDT.Infrastructure.IRepositories;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class EmployeeService: Service, IEmployeeService
    {
        private readonly IEmployeeRepository _emRepo;
        private readonly IRoleRepository _roleRepo;
        private readonly EmployeeManager _emManager;
        public EmployeeService(IEmployeeRepository emRepo, IRoleRepository roleRepo, EmployeeManager emManager, IMapper mapper):base(mapper)
        {
            _emRepo = emRepo;
            _roleRepo = roleRepo;
            _emManager = emManager;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeeAsync()
        {
            var list = await _emRepo.GetCanChangeListAllAsync();
            foreach(var item in list)
            {
                item.RoleNoNavigation = await _roleRepo.GetRecordByNo(item.RoleNo);
            }
            var dtoList = _mapper.Map<List<EmployeeDto>>(list);
            return dtoList;
        }

        public async Task<EmployeeDto> GetEmployeeRecordByNoAsync(string no)
        {
            var employee = await _emRepo.GetRecordByNoAsync(no);
            if (employee != null)
            {
                employee.RoleNoNavigation = await _roleRepo.GetRecordByNo(employee.RoleNo);
                return _mapper.Map<EmployeeDto>(employee);
            }
            else
                throw new Exception(string.Format("Employee no {0} not found", no));
        }

        public async Task<EmployeeDto> InsertNewEmployeeAsync(EmployeeDto entityDto)
        {
            var employee = await _emManager.AddEmployeeAsync(entityDto);
            var dto = _mapper.Map<EmployeeDto>(await _emRepo.InsertNewAsync(employee));
            return dto;
        }

        public  async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto entityDto)
        {
            var employee = await _emManager.UpdateEmployeeAsync(entityDto);
            var dto = _mapper.Map<EmployeeDto>(await _emRepo.UpdateAsync(employee));
            return dto;
        }
        public async Task<EmployeeDto> DeleteEmployeeAsync(EmployeeDto entityDto)
        {
            var employee = await _emManager.DeleteEmployeeAsync(entityDto);
            var dto = _mapper.Map<EmployeeDto>(await _emRepo.DeleteAsync(employee));
            return dto;
        }

        public async Task<List<RoleDto>> GetListRoleAsync()
        {
            return _mapper.Map<List<RoleDto>>(await _roleRepo.GetListRole());
        }

        public async Task<List<EmployeeDto>> SearchEmployee(string empNo, string empName, string dateOfBirth, string phoneNumber, string email)
        {
            var list = await _emRepo.SearchEmployee(empNo, empName, dateOfBirth, phoneNumber, email);
            foreach (var item in list)
            {
                item.RoleNoNavigation = await _roleRepo.GetRecordByNo(item.RoleNo);
            }
            var dtoList = _mapper.Map<List<EmployeeDto>>(list);
            return dtoList;
        }

        public async Task<EmployeeDto> GetEmployeeCredential(string email, string passWord)
        {
            var employee = await _emRepo.GetEmployeeCredential(email, passWord);
            if (employee != null)
            {
                employee.RoleNoNavigation = await _roleRepo.GetRecordByNo(employee.RoleNo);
                return _mapper.Map<EmployeeDto>(employee);
            }
            else
                throw new Exception(string.Format("Wrong password or user does not exist"));
        }
    }
}
