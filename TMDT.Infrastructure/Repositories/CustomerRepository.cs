using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<List<Customer>> CheckOldPassWord(string cusNo, string passWord)
        {
            return await _dbContext.Customers.Where(n => n.CustomerNo == cusNo && n.PassWord == passWord).AsNoTracking().ToListAsync();
        }

        public async Task<List<Customer>> CheckUniqueEmail(string customerNo, string email)
        {
            return await _dbContext.Customers.Where(n => n.Email == email && n.CustomerNo != customerNo).AsNoTracking().ToListAsync();
        }

        public async Task<List<Customer>> CheckUniquePhoneNumber(string customerNo, string phoneNumber)
        {
            return await _dbContext.Customers.Where(n => n.PhoneNumber == phoneNumber && n.CustomerNo != customerNo).AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomerCredential(string email, string passWord)
        {
            return await _dbContext.Customers.Where(n => n.Email == email && n.PassWord == passWord && n.Status == true).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetRecordByNo(string customerNo)
        {
            return await _dbContext.Customers.Where(n => n.CustomerNo == customerNo).AsNoTracking().ToListAsync();
        }

        public async Task<List<Customer>> SearchCustomer(string cusNo, string cusName, string phoneNumber, string email)
        {
            var cusList = new List<Customer>();
            if (cusNo != "")
            {
                cusList = await _dbContext.Customers.Where(n => n.CustomerNo.Contains(cusNo)).ToListAsync();
            }
            if (cusName != "")
            {
                if (cusList.Count > 0)
                {
                    cusList = cusList.Where(n => n.CustomerName.Contains(cusName)).ToList();
                }
                else
                    cusList = await _dbContext.Customers.Where(n => n.CustomerName.Contains(cusName)).ToListAsync();
            }
            if (phoneNumber != "")
            {
                if (cusList.Count > 0)
                {
                    cusList = cusList.Where(n => n.PhoneNumber.Contains(phoneNumber)).ToList();
                }
                else
                    cusList = await _dbContext.Customers.Where(n => n.PhoneNumber.Contains(phoneNumber)).ToListAsync();
            }
            if (email != "")
            {
                if (cusList.Count > 0)
                {
                    cusList = cusList.Where(n => n.Email.Contains(email)).ToList();
                }
                else
                    cusList = await _dbContext.Customers.Where(n => n.Email.Contains(email)).ToListAsync();
            }
            return cusList;
        }
    }
}
