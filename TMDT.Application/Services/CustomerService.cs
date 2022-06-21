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
    public class CustomerService : Service, ICustomerService
    {
        private readonly ICustomerRepository _cusRepo;
        private readonly CustomerManager _cusManager;
        private readonly IMembershipCardRepository _memCardRepo;
        private readonly ICardRankRepository _cardRankRepo;
        public CustomerService(ICustomerRepository cusRepo, CustomerManager cusManager, IMembershipCardRepository memCardRepo, ICardRankRepository cardRankRepo, IMapper mapper):base(mapper)
        {
            _cusRepo = cusRepo;
            _cusManager = cusManager;
            _memCardRepo = memCardRepo;
            _cardRankRepo = cardRankRepo;
        }
        public async Task<List<CustomerDto>> GetAllCustomerAsync()
        {
            var list = await _cusRepo.GetAllAsync();
            var dtoList = _mapper.Map<List<CustomerDto>>(list);
            return dtoList;
        }

        public async Task<CustomerDto> GetCustomerRecordByNoAsync(string no)
        {
            var cus = await _cusRepo.GetRecordByNo(no);
            if (cus != null)
            {
                return _mapper.Map<CustomerDto>(cus.First());
            }
            else
                throw new Exception(string.Format("Customer no {0} not found", no));
        }

        public async Task<CustomerDto> InsertNewCustomerAsync(CustomerDto entityDto)
        {
            var cus = await _cusManager.AddEmployeeAsync(entityDto);
            var dto = _mapper.Map<CustomerDto>(await _cusRepo.InsertNewAsync(cus));
            return dto;
        }

        public async Task<UpdateCustomerDto> UpdateCustomerAsync(UpdateCustomerDto entityDto)
        {
            var cus = await _cusManager.UpdateEmployeeAsync(entityDto);
            var dto = _mapper.Map<CustomerDto>(await _cusRepo.UpdateAsync(cus));
            return _mapper.Map<UpdateCustomerDto>(dto);
        }
        public async Task<CustomerDto> DeleteCustomerAsync(CustomerDto entityDto)
        {
            var cus = await _cusManager.DeleteEmployeeAsync(entityDto);
            var dto = _mapper.Map<CustomerDto>(await _cusRepo.DeleteAsync(cus));
            return dto;
        }

        public async Task<List<CustomerDto>> SearchCustomer(string cusNo, string cusName, string phoneNumber, string email)
        {
            var list = await _cusRepo.SearchCustomer(cusNo, cusName, phoneNumber, email);
            var dtoList = _mapper.Map<List<CustomerDto>>(list);
            return dtoList;
        }
        public async Task<CustomerDto> GetCustomerCredential(string email, string passWord)
        {
            var customer = await _cusRepo.GetCustomerCredential(email, passWord);
            var cusDto = new CustomerDto();
            if (customer != null)
            {
                var card = await _memCardRepo.CheckExistCard(customer.CustomerNo);
                if(card.Any())
                {
                    var cardEnt = card.FirstOrDefault();
                    cardEnt.RankNoNavigation = await _cardRankRepo.GetRecordByNo(cardEnt.RankNo);
                    cusDto = _mapper.Map<CustomerDto>(customer);
                    cusDto.MembershipCardNavigation = _mapper.Map<MembershipCardDto>(cardEnt);
                }
                return cusDto;
            }
            else
                throw new Exception(string.Format("Wrong password or user does not exist"));
        }
    }
}
