using AutoMapper;
using MiniExample.Data.Entities;
using MiniExample.Data.Repositories.Interfaces;
using MiniExample.Data.Repositories.Repositories;
using MiniExample.Model.Models;
using MiniExample.Model.Types.Product;
using MiniExample.Service.Interfaces;
using MiniExample.Utility.Filter;
using System.Linq.Expressions;

namespace MiniExample.Service.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateProduct(Product newProduct)
        {
            ProductEntity input = _mapper.Map<ProductEntity>(newProduct);

            try
            {
                await _productRepository.Insert(input);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(Product newProduct, int id)
        {
            ProductEntity currData = await _productRepository.GetById(id);
            if (currData == null)
            {
                return false;
            }
            currData.Name = newProduct.Name;
            currData.Description = newProduct.Description;
            currData.Price = newProduct.Price;
            currData.MakerId = newProduct.MakerId;

            try
            {
                await _productRepository.Update(currData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<GetListProductsWithPaginateResponse> GetList(PaginationFilter paginateData)
        {
            // add search string

            Expression<Func<ProductEntity, bool>> filter;

            if (!string.IsNullOrWhiteSpace(paginateData.SearchString))
            {
                filter = paginateData.SearchBy switch
                {
                    "MakerId" => e => e.MakerId == int.Parse(paginateData.SearchString),
                    "Name" => e => e.Name.Contains(paginateData.SearchString),
                    "LessThanPrice" => e => e.Price <= int.Parse(paginateData.SearchString),
                    "GreaterThanPrice" => e => e.Price >= int.Parse(paginateData.SearchString),
                    _ => e => e.Id != null,
                };
            }
            else
            {
                filter = null;
            }


            // add order 
            var orderInfo = paginateData.OrderBy + "_" + paginateData.OrderType.ToString();
            Func<IQueryable<ProductEntity>, IOrderedQueryable<ProductEntity>> orderBy = orderInfo switch
            {
                "Name_Descending" => e => e.OrderByDescending(e => e.Name),
                "Name_Ascending" => e => e.OrderBy(e => e.Name),
                "CreatedDate_Ascending" => e => e.OrderBy(e => e.CreatedDate),
                "CreatedDate_Descending" => e => e.OrderByDescending(e => e.CreatedDate),
                "Price_Ascending" => e => e.OrderBy(e => e.Price),
                "Price_Descending" => e => e.OrderByDescending(e => e.Price),
                _ => e => e.OrderBy(e => e.Id),
            };

            var data = await _productRepository.Get(filter, orderBy, includeProperties: "Maker", paginateData);
            var totalCount = await _productRepository.Count(filter);
            var rs = new GetListProductsWithPaginateResponse
            {
                Data = _mapper.Map<IEnumerable<ProductResponseItem>>(data),
                TotalCount = totalCount
            };
            return rs;
        }
    }
}
