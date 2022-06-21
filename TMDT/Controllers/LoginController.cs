using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.IServices;
using TMDT.Shared.Dto;
using TMDT.ViewModels;
using TMDT.ViewModels.Base;

namespace TMDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IEmployeeService _emService;
        private readonly ICustomerService _cusService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public LoginController(IEmployeeService emService, ICustomerService cusService, IMapper mapper, IConfiguration config)
        {
            _emService = emService;
            _cusService = cusService;
            _mapper = mapper;
            _config = config;
        }
        [HttpPost]
        public async Task<object> Login(LoginViewModel viewModel)
        {
            try
            {
                if(viewModel.Type)
                {
                    var empDto = await _emService.GetEmployeeCredential(viewModel.Email, viewModel.PassWord);

                    if (empDto != null)
                    {
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var crendentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, empDto.EmployeeNo.ToString()),
                            new Claim(ClaimTypes.Name, empDto.EmployeeName),
                            new Claim(ClaimTypes.Role, empDto.RoleNoNavigation.RoleName)
                        };

                        var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: crendentials);
                        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                        //var identity = new ClaimsIdentityg(claims, "CookieAuthentication");
                        //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                        Credential model = new Credential();
                        model.Id = empDto.EmployeeNo;
                        model.UserName = empDto.EmployeeName;
                        model.Email = empDto.Email;
                        model.TypeUser = true;
                        model.RoleId = empDto.RoleNo.ToString();
                        model.RoleName = empDto.RoleNoNavigation.RoleName;
                        model.Token = tokenString;

                        return new ResultViewModel<object>(ViewModels.Base.StatusCode.OK, "Login successfully", model);
                    }
                    else
                        return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", "User not found");
                }
                else
                {
                    var cusDto = await _cusService.GetCustomerCredential(viewModel.Email, viewModel.PassWord);
                    if (cusDto != null)
                    {
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var crendentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, cusDto.CustomerNo.ToString()),
                            new Claim(ClaimTypes.Name, cusDto.CustomerName),
                            new Claim(ClaimTypes.Role, cusDto.MembershipCardNavigation.RankNoNavigation.RankName)
                        };

                        var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: crendentials);
                        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                        //var identity = new ClaimsIdentityg(claims, "CookieAuthentication");
                        //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                        ClientCredential model = new ClientCredential();
                        model.CustomerNo = cusDto.CustomerNo;
                        model.CustomerName = cusDto.CustomerName;
                        model.CustomerAddress = cusDto.CustomerAddress;
                        model.Email = cusDto.Email;
                        model.PhoneNumber = cusDto.PhoneNumber;
                        model.RoleId = cusDto.MembershipCardNavigation.RankNo.ToString();
                        model.RoleName = cusDto.MembershipCardNavigation.RankNoNavigation.RankName;
                        model.Token = tokenString;

                        return new ResultViewModel<object>(ViewModels.Base.StatusCode.OK, "Login successfully", model);
                    }
                    else
                        return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", "User not found");
                }  
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
