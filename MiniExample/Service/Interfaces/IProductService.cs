using MiniExample.Model.Models;
using MiniExample.Model.Types.Product;
using MiniExample.Utility.Filter;

namespace MiniExample.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProduct(Product newProduct);
        Task<bool> UpdateProduct(Product newProduct, int id);
        Task<GetListProductsWithPaginateResponse> GetList(PaginationFilter paginateData);
    }
}
