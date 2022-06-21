using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Application.Base;
using TMDT.Application.IServices;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Services
{
    public class PurchaseOrderLineService:Service, IPurchaseOrderLineService
    {
        private readonly IPurchaseOrderLineRepository _polRepo;
        private readonly ISerialProductRepository _seProRepo;
        private readonly IProductRepository _proRepo;
        public PurchaseOrderLineService(IPurchaseOrderLineRepository polRepo, ISerialProductRepository seProRepo, IProductRepository proRepo, IMapper mapper):base(mapper)
        {
            _polRepo = polRepo;
            _seProRepo = seProRepo;
            _proRepo = proRepo;
        }

        public async Task<AddPurchaseOrderLineDto> InsertNewPurchaseOrderLineAsync(AddPurchaseOrderLineDto entityDto)
        {
            var pol = await _polRepo.InsertNewAsync(_mapper.Map<PurchaseOrderLine>(entityDto));
            return _mapper.Map<AddPurchaseOrderLineDto>(pol);
        }

        public async Task<List<PurchaseOrderLineDto>> InsertListPurchaseOrderLineAsync(List<PurchaseOrderLineDto> listEntityDto)
        {
            foreach(var item in listEntityDto)
            {
                await _polRepo.InsertNewAsync(_mapper.Map<PurchaseOrderLine>(item));
            }
            return listEntityDto;
        }

        public async Task<PurchaseOrderLineDto> UpdatePurchaseOrderLineAsync(PurchaseOrderLineDto entityDto)
        {
            var pol = await _polRepo.UpdateAsync(_mapper.Map<PurchaseOrderLine>(entityDto));
            return _mapper.Map<PurchaseOrderLineDto>(pol);
        }

        public  async Task<PurchaseOrderLineDto> DeletePurchaseOrderLineAsync(PurchaseOrderLineDto entityDto)
        {
            var pol = await _polRepo.DeleteAsync(_mapper.Map<PurchaseOrderLine>(entityDto));
            return _mapper.Map<PurchaseOrderLineDto>(pol);
        }

        public async Task<List<PurchaseOrderLineDto>> GetPurchaseOrderLineListByOrderNo(int orderNo)
        {
            var list = await _polRepo.GetListByOrderNo(orderNo);
            var dtoList = new List<PurchaseOrderLineDto>();
            var dto = new PurchaseOrderLineDto();
            foreach(var item in list)
            {
                var sePro = await _seProRepo.GetRecordByNoAsync(item.SerialNo);
                var pro = await _proRepo.GetRecordByNoAsync(sePro.ProductNo);
                dto = new PurchaseOrderLineDto(item.OrderNo, pro.ProductName, item.QuantityOrdered.Value, item.BuyPrice.Value);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
