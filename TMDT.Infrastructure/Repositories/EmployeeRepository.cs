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
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration config):base(config)
        {
        }

        public async Task<List<Employee>> CheckUniqueEmail(string employeeNo, string email)
        {
            return await _dbContext.Employees.Where(n => n.Email == email && n.EmployeeNo != employeeNo).ToListAsync();
        }

        public async Task<List<Employee>> CheckUniquePhoneNumber(string employeeNo, string phoneNumber)
        {
            return await _dbContext.Employees.Where(n => n.PhoneNumber == phoneNumber && n.EmployeeNo != employeeNo).ToListAsync();
        }

        public async Task<Employee> GetEmployeeCredential(string email, string passWord)
        {
            return await _dbContext.Employees.Where(n => n.Email == email && n.PassWord == passWord && n.Status == true).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> SearchEmployee(string empNo, string empName, string dateOfBirth, string phoneNumber, string email)
        {
            var empList = new List<Employee>();
            if (empNo != "")
            {
                empList = await _dbContext.Employees.Where(n => n.EmployeeNo.Contains(empNo)).ToListAsync();
            }
            if(empName != "")
            {
                if (empList.Count > 0)
                {
                    empList = empList.Where(n => n.EmployeeName.Contains(empName)).ToList();
                }
                else
                    empList = await _dbContext.Employees.Where(n => n.EmployeeName.Contains(empName)).ToListAsync();
            }
            if (phoneNumber != "")
            {
                if (empList.Count > 0)
                {
                    empList = empList.Where(n => n.PhoneNumber.Contains(phoneNumber)).ToList();
                }
                else
                    empList = await _dbContext.Employees.Where(n => n.PhoneNumber.Contains(phoneNumber)).ToListAsync();
            }
            if (email != "")
            {
                if (empList.Count > 0)
                {
                    empList = empList.Where(n => n.Email.Contains(email)).ToList();
                }
                else
                    empList = await _dbContext.Employees.Where(n => n.Email.Contains(email)).ToListAsync();
            }
            if (dateOfBirth != "")
            {
                DateTime date = (Convert.ToDateTime(dateOfBirth));
                if (empList.Count > 0)
                    empList = empList.Where(n => n.DateOfBirth.Day == date.Day && n.DateOfBirth.Month == date.Month && n.DateOfBirth.Year == date.Year).ToList();
                else
                    empList = await _dbContext.Employees.Where(n => n.DateOfBirth.Day == date.Day && n.DateOfBirth.Month == date.Month && n.DateOfBirth.Year == date.Year).ToListAsync();
            }
            return empList;
        }
    }
}
