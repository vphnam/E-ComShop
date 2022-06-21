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
    public class ProductDescriptionController : BaseController
    {
        private readonly IProductDescriptionService _proDescService;
        public ProductDescriptionController(IProductDescriptionService proDescService, IMapper mapper, Helper helper) : base(mapper, helper)
        {
            _proDescService = proDescService;
        }
        [HttpGet]
        public async Task<object> GetList()
        {
            try
            {
                var list = await _proDescService.GetAllProductDescriptionAsync();
                var returnData = _mapper.Map<List<ProductDescriptionViewModel>>(list);
                return new ResultViewModel<List<ProductDescriptionViewModel>>(ViewModels.Base.StatusCode.OK, "Done: Get product description list successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("GetOneRecord")]
        public async Task<object> GetByNo(GetProductDescriptionViewModel viewModel)
        {
            try
            {
                var productDescDto = await _proDescService.GetProductDescriptionRecordByNoAsync(viewModel.ProductDescNo, viewModel.ProductNo);
                var returnData = _mapper.Map<ProductDescriptionViewModel>(productDescDto);
                return new ResultViewModel<ProductDescriptionViewModel>(ViewModels.Base.StatusCode.OK, string.Format("Done: Get record with no: {0}, {1} and successfully", viewModel.ProductDescNo, viewModel.ProductNo), returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost]
        public async Task<object> Add(ProductDescriptionViewModel proDescViewModel)
        {
            try
            {
                proDescViewModel.ProductDescNo = _helper.GenerateId();
                var productDescDto = await _proDescService.InsertNewProductDescriptionAsync(_mapper.Map<ProductDescDto>(proDescViewModel));
                var returnData = _mapper.Map<ProductDescriptionViewModel>(productDescDto);
                return new ResultViewModel<ProductDescriptionViewModel>(ViewModels.Base.StatusCode.OK, "Done: New product description has been created successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<object> Update(ProductDescriptionViewModel proDescViewModel)
        {
            try
            {
                var productDescDto = await _proDescService.UpdateProductDescriptionAsync(_mapper.Map<ProductDescDto>(proDescViewModel));
                var returnData = _mapper.Map<ProductDescriptionViewModel>(productDescDto);
                return new ResultViewModel<ProductDescriptionViewModel>(ViewModels.Base.StatusCode.OK, "Done: Product description has been updated successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<object> Delete(ProductDescriptionViewModel proDescViewModel)
        {
            try
            {
                var productDescDto = await _proDescService.DeleteProductDescriptionAsync(_mapper.Map<ProductDescDto>(proDescViewModel));
                var returnData = _mapper.Map<ProductDescriptionViewModel>(productDescDto);
                return new ResultViewModel<ProductDescriptionViewModel>(ViewModels.Base.StatusCode.OK, "Done: Product description has been deleted successfully!", returnData);
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string>(ViewModels.Base.StatusCode.Error, "Error: Opps! An error occurred while processing your request", ex.Message);
            }
        }
    }
}
