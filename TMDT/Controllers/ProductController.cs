using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDT.Application.IServices;
using TMDT.Helpers;
using TMDT.Shared.Dto;
using TMDT.ViewModels;
using TMDT.ViewModels.Base;

namespace TMDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService, IMapper mapper, Helper helper):base(mapper, helper)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<object> GetList()
        {
            try
            {
                var list = await _productService.GetAllProductAsync();
                var returnData = _mapper.Map<List<ProductListViewModel>>(list);
                return new ResultViewModel<List<ProductListViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get product list successfully!", returnData);
            }
            catch(Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.OK, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpGet("GetByNo")]
        public async Task<object> GetByNo(string no)
        {
            try
            {
                var productDto = await _productService.GetProductRecordByNoAsync(no);
                var returnData = _mapper.Map<ProductDetailViewModel>(productDto);
                return new ResultViewModel<ProductDetailViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with product no: {0} successfully", no), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(ProductViewModel productDetailViewModel)
        {
            try
            {
                productDetailViewModel.ProductNo = _helper.GenerateId();
                var productDto = await _productService.InsertNewProductAsync(_mapper.Map<ProductDetailDto>(productDetailViewModel));
                var returnData = _mapper.Map<ProductViewModel>(productDto);
                return new ResultViewModel<ProductViewModel>(ViewModels.Base.StatusCode.OK, "Done: New product has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(ProductViewModel productDetailViewModel)
        {
            try
            {
                var productDto = await _productService.UpdateProductAsync(_mapper.Map<ProductDetailDto>(productDetailViewModel));
                var returnData = _mapper.Map<ProductViewModel>(productDto);
                return new ResultViewModel<ProductViewModel>(ViewModels.Base.StatusCode.OK, "Done: Product has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(ProductViewModel productDetailViewModel)
        {
            try
            {
                var productDto = await _productService.DeleteProductAsync(_mapper.Map<ProductDetailDto>(productDetailViewModel));
                var returnData = _mapper.Map<ProductViewModel>(productDto);
                return new ResultViewModel<ProductViewModel>(ViewModels.Base.StatusCode.OK, "Done: Product has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
