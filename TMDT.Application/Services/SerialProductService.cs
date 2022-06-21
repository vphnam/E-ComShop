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
    public class SerialProductService: Service, ISerialProductService
    {
        private readonly ISerialProductRepository _serialProRepo;
        private readonly IColorRepository _colorRepo;
        private readonly ISizeRepository _sizeRepo;
        private readonly IProductRepository _proRepo;
        private readonly IPromotionRepository _promoRepo;
        private readonly SerialProductManager _serialProManager;
        private readonly ISerialProImageRepository _seImgRepo;
        public SerialProductService(ISerialProductRepository serialProRepo, SerialProductManager serialProManager, IColorRepository colorRepo, ISizeRepository sizeRepo, 
            IProductRepository proRepo, IPromotionRepository promoRepo, IMapper mapper, ISerialProImageRepository seImgRepo) :base(mapper)
        {
            _serialProRepo = serialProRepo;
            _serialProManager = serialProManager;
            _colorRepo = colorRepo;
            _sizeRepo = sizeRepo;
            _proRepo = proRepo;
            _promoRepo = promoRepo;
            _seImgRepo = seImgRepo;
        }

        public async Task<List<DisplayProductDto>> GetAllSerialProductAsync()
        {
            var list = await _serialProRepo.GetAllAsync();
            var disList = new List<DisplayProductDto>();

            foreach(var item in list)
            {
                bool flag = false;
                foreach (var dis in disList)
                {
                    var colorFlag = await _colorRepo.GetRecordByNoAsync(item.ColorNo);
                    if (item.ProductNo == dis.ProductNo && colorFlag.ColorName == dis.Color)
                    {
                        flag = true;
                    }
                }
                if(!flag)
                {
                    var color = await _colorRepo.GetRecordByNoAsync(item.ColorNo);
                    var product = await _proRepo.GetRecordByNoAsync(item.ProductNo);
                    var promo = await _promoRepo.GetRecordByNoAsync(item.PromotionNo);
                    var disAdd = new DisplayProductDto(item.SerialNo, item.ProductNo, product.ProductName + " - " + color.ColorName, item.ProductDetailImage, Convert.ToDecimal(product.Price), item.ProductDetailDescription, color.ColorName, _mapper.Map<PromotionDto>(promo), item.Quantity);
                    disList.Add(disAdd);
                }
            }
            return disList;
        }

        public async Task<DisplaySingleProduct> GetSerialProductRecordByNoAsync(string no)
        {
            var serialProduct = await _serialProRepo.GetRecordByNoAsync(no);
            if (serialProduct != null)
            {
                var color = await _colorRepo.GetRecordByNoAsync(serialProduct.ColorNo);
                var product = await _proRepo.GetRecordByNoAsync(serialProduct.ProductNo);
                var promo = await _promoRepo.GetRecordByNoAsync(serialProduct.PromotionNo);
                var imgs = await _seImgRepo.GetImagesBySerialNo(serialProduct.SerialNo);
                var dis = new DisplaySingleProduct(serialProduct.SerialNo, serialProduct.ProductNo, product.ProductName + " - " + color.ColorName, serialProduct.ProductDetailImage, Convert.ToDecimal(product.Price), serialProduct.ProductDetailDescription, color.ColorName, _mapper.Map<PromotionDto>(promo), serialProduct.Quantity, imgs);
                return dis;
            }
            else
                throw new Exception(string.Format("Serial product no {0} not found", no));

        }

        public async Task<SerialProductDto> InsertNewSerialProductAsync(SerialProductDto entityDto)
        {
            var serialProduct = await _serialProManager.AddSerialProductAsync(entityDto);
            var returnSerialProduct = await _serialProRepo.InsertNewAsync(serialProduct);
            return _mapper.Map<SerialProductDto>(returnSerialProduct);
        }

        public async Task<SerialProductDto> UpdateSerialProductAsync(SerialProductDto entityDto)
        {
            var serialProduct = await _serialProManager.UpdateSerialProductAsync(entityDto);
            var returnSerialProduct = await _serialProRepo.UpdateAsync(serialProduct);
            return _mapper.Map<SerialProductDto>(returnSerialProduct);
        }
        public  async Task<SerialProductDto> DeleteSerialProductAsync(SerialProductDto entityDto)
        {
            var serialProduct = await _serialProManager.DeleteSerialProductAsync(entityDto);
            var returnSerialProduct = await _serialProRepo.DeleteAsync(serialProduct);
            return _mapper.Map<SerialProductDto>(returnSerialProduct);
        }

    }
}
