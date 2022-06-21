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
    public class PurchaseOrderManager
    {
        private readonly IPurchaseOrderRepository _poRepo;
        private readonly IMapper _mapper;
        public PurchaseOrderManager(IPurchaseOrderRepository poRepo, IMapper mapper)
        {
            _poRepo = poRepo;
            _mapper = mapper;
        }
        public async Task<PurchaseOrder> AddPurchaseOrderAsync(AddPurchaseOrderDto poDto)
        {
            var check = await _poRepo.CheckUsedVoucher(poDto.CustomerNo, poDto.VoucherNo);
            if (!check)
            {
                return _mapper.Map<PurchaseOrder>(poDto);
            }
            else
                throw new Exception(string.Format("Voucher {0} has been used before", poDto.VoucherNo));
        }
        public async Task<PurchaseOrder> UpdatePurchaseOrderAsync(int no, int code, string note)
        {
            var po = await _poRepo.GetRecordByIntAsync(no);
            po.Note = note;
            po.ProcessStatus = code;
            return po;
        }
        public async Task<PurchaseOrder> CancelPurchaseOrderAsync(int no, bool status)
        {
            var po = await _poRepo.GetRecordByIntAsync(no);
            po.Status = status;
            return po;
        }
        public List<PurchaseOrderDto> ConvertPurchaseOrderModelToPurchaseOrderListDto(List<PurchaseOrder> poList)
        {
            List<PurchaseOrderDto> listDto = new List<PurchaseOrderDto>();
            var dto = new PurchaseOrderDto();
            foreach(var item in poList)
            {
                dto = new PurchaseOrderDto(item.OrderNo, item.OrderDate, item.DeliveryAddress, item.CustomerNoNavigation.CustomerName, (item.EmployeeNoNavigation == null) ? null: item.EmployeeNoNavigation.EmployeeName, item.VoucherNo, item.Note,
                    item.SentMail, item.ProcessStatus, item.Status);
                listDto.Add(dto);
            }
            return listDto;
        }
    }
}
