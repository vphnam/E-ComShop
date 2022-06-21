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
    public class CustomerManager
    {
        private readonly ICustomerRepository _cusRepo;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerRepository cusRepo, IMapper mapper)
        {
            _cusRepo = cusRepo;
            _mapper = mapper;
        }
        public async Task<Customer> AddEmployeeAsync(CustomerDto cus)
        {
            cus.Status = true;
            var checkEmail = await _cusRepo.CheckUniqueEmail(cus.CustomerNo, cus.Email);
            var checkPhoneNumber = await _cusRepo.CheckUniquePhoneNumber(cus.CustomerNo, cus.PhoneNumber);
            if (!checkEmail.Any() && !checkPhoneNumber.Any())
            {
                if (!checkPhoneNumber.Any())
                {
                    return _mapper.Map<Customer>(cus);
                }
                else
                {
                    throw new Exception(string.Format("Phone number {0} already exist", cus.PhoneNumber));
                }
            }
            else
                throw new Exception(string.Format("Email {0} already exist", cus.Email));
        }
        public async Task<Customer> UpdateEmployeeAsync(UpdateCustomerDto cus)
        {
            var checkPassword = await _cusRepo.CheckOldPassWord(cus.CustomerNo, cus.OldPassWord);
            var checkEmail = await _cusRepo.CheckUniqueEmail(cus.CustomerNo, cus.Email);
            var checkPhoneNumber = await _cusRepo.CheckUniquePhoneNumber(cus.CustomerNo, cus.PhoneNumber);
            if (checkPassword.Any())
            {
                if (!checkEmail.Any() && !checkPhoneNumber.Any())
                {
                    if (!checkPhoneNumber.Any())
                    {
                        return _mapper.Map<Customer>(cus);
                    }
                    else
                    {
                        throw new Exception(string.Format("Phone number {0} already exist", cus.PhoneNumber));
                    }
                }
                else
                    throw new Exception(string.Format("Email {0} already exist", cus.Email));
            }
            else
                throw new Exception(string.Format("Old pass word is not valid"));
        }
        public async Task<Customer> DeleteEmployeeAsync(CustomerDto cus)
        {
            return _mapper.Map<Customer>(cus);
        }
    }
}
