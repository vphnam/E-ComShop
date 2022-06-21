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
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class PurchaseOrderService: Service, IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _poRepo;
        private readonly IPurchaseOrderLineRepository _polRepo;
        private readonly IFeedbackRepository _fbRepo;
        private readonly ICustomerRepository _cusRepo;
        private readonly IEmployeeRepository _empRepo;
        private readonly IVoucherRepository _vcRepo;
        private readonly IMembershipCardRepository _memCardRepo;
        private readonly PurchaseOrderManager _poManager;
        public PurchaseOrderService(IPurchaseOrderRepository poRepo, IPurchaseOrderLineRepository polRepo, IFeedbackRepository fbRepo,
            ICustomerRepository cusRepo, IEmployeeRepository empRepo, PurchaseOrderManager poManager,
            IMembershipCardRepository memCardRepo, IVoucherRepository vcRepo, IMapper mapper):base(mapper)
        {
            _poRepo = poRepo;
            _polRepo = polRepo;
            _fbRepo = fbRepo;
            _cusRepo = cusRepo;
            _empRepo = empRepo;
            _poManager = poManager;
            _vcRepo = vcRepo;
            _memCardRepo = memCardRepo;
        }

        public async Task<List<PurchaseOrderDto>> GetAllPurchaseOrderAsync()
        {
            var list = await _poRepo.GetCanChangeListAllAsync();
            foreach (var item in list)
            {
                item.EmployeeNoNavigation = await _empRepo.GetRecordByNoAsync(item.EmployeeNo);
                item.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(item.CustomerNo);
            }
            return _poManager.ConvertPurchaseOrderModelToPurchaseOrderListDto(list);
        }

        public async Task<object> InsertNewPurchaseOrderAsync(AddPurchaseOrderDto entityDto)
        {
            var po = await _poManager.AddPurchaseOrderAsync(entityDto);
            double total = 0;
            if (po != null)
            {
                po.OrderDate = DateTime.Now;
                po.SentMail = false;
                po.ProcessStatus = 1;
                po.Status = true;
                po = await _poRepo.InsertNewAsync(po);
                foreach(var item in entityDto.ListPurchaseOrderLines)
                {
                    item.OrderNo = po.OrderNo;
                    total += ((double)item.BuyPrice * item.QuantityOrdered);
                    await _polRepo.InsertNewAsync(_mapper.Map<PurchaseOrderLine>(item));
                }
                var card = await _memCardRepo.GetCardByCustomerNo(entityDto.CustomerNo);
                if (card != null)
                {
                    card.Point += (int)total/1000;
                    if (card.Point < 1000)
                        card.RankNo = 1;
                    else if (card.Point >= 1000 && card.Point < 3000)
                        card.RankNo = 2;
                    else if (card.Point >= 3000 && card.Point < 5000)
                        card.RankNo = 3;
                    else if (card.Point >= 5000 && card.Point < 10000)
                        card.RankNo = 4;
                    else if (card.Point >= 10000 && card.Point < 15000)
                        card.RankNo = 5;
                    else
                        card.RankNo = 6;
                }
                await _memCardRepo.UpdateAsync(card);
            }
            return po;
        }

        public async Task<PurchaseOrderDto> UpdatePurchaseOrderAsync(int no, int code, string note)
        {
            var po = await _poManager.UpdatePurchaseOrderAsync(no, code, note);
            po = await _poRepo.UpdateAsync(po);
            po.EmployeeNoNavigation = await _empRepo.GetRecordByNoAsync(po.EmployeeNo);
            po.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(po.CustomerNo);
            return new PurchaseOrderDto(po.OrderNo, po.OrderDate, po.DeliveryAddress, po.CustomerNoNavigation.CustomerName, po.EmployeeNoNavigation.EmployeeName,
                po.VoucherNo, po.Note, po.SentMail, po.ProcessStatus, po.Status);
        }
        public async Task<PurchaseOrderDto> CancelPurchaseOrderAsync(int no, bool status)
        {
            var po = await _poManager.CancelPurchaseOrderAsync(no, status);
            po = await _poRepo.UpdateAsync(po);
            po.EmployeeNoNavigation = await _empRepo.GetRecordByNoAsync(po.EmployeeNo);
            po.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(po.CustomerNo);
            return new PurchaseOrderDto(po.OrderNo, po.OrderDate, po.DeliveryAddress, po.CustomerNoNavigation.CustomerName, po.EmployeeNoNavigation.EmployeeName,
                po.VoucherNo, po.Note, po.SentMail, po.ProcessStatus, po.Status);
        }

        public async Task<List<DashBoardTableDto>> GetDashBoardTable()
        {
            var table = new List<DashBoardTableDto>()
            {
                new DashBoardTableDto(0,"Failed",0),
                new DashBoardTableDto(1,"Received",0),
                new DashBoardTableDto(2,"Processing",0),
                new DashBoardTableDto(3,"Confirmed",0),
                new DashBoardTableDto(4,"Arrived at shipping partner",0),
                new DashBoardTableDto(5,"Delivered",0),
                new DashBoardTableDto(6,"Waiting to complete",0),
                new DashBoardTableDto(7,"Return and refund",0),
                new DashBoardTableDto(8,"Done",0),
            };
            foreach(var item in table)
            {
                item.QuantityOrder = await _poRepo.CountByProcessStatusCode(item.ProcessStatusCode);
            }
            return table;
        }

        public async Task<List<PurchaseOrderDto>> GetListByProcessStatus(int code)
        {
            var list = await _poRepo.GetListByProcessStatus(code);
            foreach(var item in list)
            {
                item.EmployeeNoNavigation = await _empRepo.GetRecordByNoAsync(item.EmployeeNo);
                item.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(item.CustomerNo);
            }
            return _poManager.ConvertPurchaseOrderModelToPurchaseOrderListDto(list);
        }
        public async Task<PurchaseOrderDto> GetPurchaseOrderRecordByNoAsync(int no)
        {
            var po = await _poRepo.GetRecordByIntAsync(no);
            po.EmployeeNoNavigation = await _empRepo.GetRecordByNoAsync(po.EmployeeNo);
            po.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(po.CustomerNo);
            return new PurchaseOrderDto(po.OrderNo, po.OrderDate, po.DeliveryAddress, po.CustomerNoNavigation.CustomerName, po.EmployeeNoNavigation.EmployeeName,
                po.VoucherNo, po.Note, po.SentMail, po.ProcessStatus, po.Status);
        }

        public async Task<List<PurchaseOrderDto>> SearchPurchaseOrder(string orderNo, string customerInfo, string employeeInfo, string voucherNo, string orderDate, string status)
        {
            var list = await _poRepo.SearchPurchaseOrder(orderNo, customerInfo, employeeInfo, voucherNo, orderDate, status);
            foreach (var item in list)
            {
                item.EmployeeNoNavigation = await _empRepo.GetRecordByNoAsync(item.EmployeeNo);
                item.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(item.CustomerNo);
            }
            return _poManager.ConvertPurchaseOrderModelToPurchaseOrderListDto(list);
        }

        public async Task<VoucherDto> ApplyVoucher(string customerNo, string voucherNo)
        {
            var vc = await _vcRepo.GetRecordByNoAsync(voucherNo);
            if (vc != null)
            {
                if (vc.StartDate > DateTime.Now || vc.EndDate < DateTime.Now)
                    throw new Exception(string.Format("Voucher {0} không còn hợp lệ", voucherNo));
                else
                {
                    if (await _poRepo.CheckUsedVoucher(customerNo, voucherNo))
                    {
                        throw new Exception(string.Format("Voucher {0} đã được sử dụng", voucherNo));
                    }
                    else
                        return _mapper.Map<VoucherDto>(vc);
                }
            }
            else
                throw new Exception(string.Format("Voucher {0} không tồn tại", voucherNo));
        }

        public async Task<List<PurchaseOrderDto>> GetListByCustomerNo(string no)
        {
            var list = await _poRepo.GetListByCustomerNo(no);
            foreach (var item in list)
            {
                item.EmployeeNoNavigation = await _empRepo.GetRecordByNoAsync(item.EmployeeNo);
                item.CustomerNoNavigation = await _cusRepo.GetRecordByNoAsync(item.CustomerNo);
            }
            return _poManager.ConvertPurchaseOrderModelToPurchaseOrderListDto(list);
        }
    }
}
