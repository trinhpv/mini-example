using MiniExample.Model.Models;
using MiniExample.Model.Types.Paginating;
using System.ComponentModel;

namespace MiniExample.Model.Types.Product
{
    public class GetListProductsWithPaginateResponse
    {
        public IEnumerable<ProductResponseItem> Data { get; set; }
        public int TotalCount { get; set; }
    }
    public class ProductResponseItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int MakerId { get; set; }
        public MakerInfo Maker { get; set; } = null!;
    }



    public class GetProductsPaginateParams : PaginateParams
    {
        public OrderRequestProduct OrderBy { get; set; }
        public SearchByRequestProduct SearchBy { get; set; }
    }


    public enum OrderRequestProduct
    {
        Name,
        CreatedDate,
        Price,
    } 
    
    public enum SearchByRequestProduct
    {
        [Description("MakerId")]
        MakerId = 0,
        Name,
        LessThanPrice,
        GreaterThanPrice,
    }

    
}
