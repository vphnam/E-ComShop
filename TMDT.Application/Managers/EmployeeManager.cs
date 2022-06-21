using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Managers
{
    public class EmployeeManager
    {
        private readonly IEmployeeRepository _emRepo;
        private readonly IMapper _mapper;
        public EmployeeManager(IEmployeeRepository emRepo, IMapper mapper)
        {
            _emRepo = emRepo;
            _mapper = mapper;
        }
        public async Task<Employee> AddEmployeeAsync(EmployeeDto em)
        {
            em.Status = true;
            var checkEmail = await _emRepo.CheckUniqueEmail(em.EmployeeNo, em.Email);
            var checkPhoneNumber = await _emRepo.CheckUniquePhoneNumber(em.EmployeeNo, em.PhoneNumber);
            if (!checkEmail.Any())
            {
                if(!checkPhoneNumber.Any())
                {
                    return _mapper.Map<Employee>(em);
                }
                else
                {
                    throw new Exception(string.Format("Phone number {0} already exist", em.PhoneNumber));
                }
            }
            else
                throw new Exception(string.Format("Email {0} already exist", em.Email));
        }
        public async Task<Employee> UpdateEmployeeAsync(EmployeeDto em)
        {
            var checkEmail = await _emRepo.CheckUniqueEmail(em.EmployeeNo, em.Email);
            var checkPhoneNumber = await _emRepo.CheckUniquePhoneNumber(em.EmployeeNo, em.PhoneNumber);
            if (!checkEmail.Any() && !checkPhoneNumber.Any())
            {
                if (!checkPhoneNumber.Any())
                {
                    return _mapper.Map<Employee>(em);
                }
                else
                {
                    throw new Exception(string.Format("Phone number {0} already exist", em.PhoneNumber));
                }
            }
            else
                throw new Exception(string.Format("Email {0} already exist", em.Email));
        }
        public async Task<Employee> DeleteEmployeeAsync(EmployeeDto em)
        {
            return _mapper.Map<Employee>(em);
        }
    }
}
