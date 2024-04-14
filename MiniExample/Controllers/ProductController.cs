using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniExample.Model.Models;
using MiniExample.Model.Types.Product;
using MiniExample.Model.Wrapper;
using MiniExample.Service.Interfaces;
using MiniExample.Service.Services;
using MiniExample.Utility.Filter;

namespace MiniExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) {
        
            _productService = productService;
        }
        [Route("/[controller]/Create")]
        [HttpPost]
        public async Task<MyResponse<bool>> Create([FromBody] CreateProductDto newProductData)
        {
            var input = new Product
            {
                Name = newProductData.Name,
                Description = newProductData.Description,
                Price = newProductData.Price,
                MakerId = newProductData.MakerId,
            };
            bool result = await _productService.CreateProduct(input);

            return new MyResponse<bool>(result);
        }

        [Route("/[controller]/Update/{id}")]
        [HttpPost]
        public async Task<MyResponse<bool>> Update([FromBody] CreateProductDto newProductData, int id)
        {
            var input = new Product
            {
                Name = newProductData.Name,
                Description = newProductData.Description,
                Price = newProductData.Price,

            };

            bool updateStatus = await _productService.UpdateProduct(input, id);
            return new MyResponse<bool>(updateStatus);
        }

        [Route("/[controller]/GetList")]
        [HttpGet]
        public async Task<MyPagedResponse<IEnumerable<ProductResponseItem>>> GetList([FromQuery] GetProductsPaginateParams paginateParams)
        {
            var paginateData = new PaginationFilter
            {
                PageNumber = paginateParams.PageNumber,
                PageSize = paginateParams.PageSize,
                SearchBy = paginateParams.SearchBy.ToString(),
                SearchString = paginateParams.SearchString,
                OrderBy = paginateParams.OrderBy.ToString(),
                OrderType = paginateParams.OrderType,

            };
            var result = await _productService.GetList(paginateData);
            return new MyPagedResponse<IEnumerable<ProductResponseItem>>(result.Data, paginateData.PageNumber, paginateData.PageSize, result.TotalCount);
        }
    }
    
}
