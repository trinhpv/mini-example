using MiniExample.Data.Repositories.Interfaces;
using MiniExample.Data.Datacontext;
using MiniExample.Data.Entities;

namespace MiniExample.Data.Repositories.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(MiniContext _context) : base(_context)
        {
            this.Context = _context;
        }
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            var products = this.Context.Products.ToList();
            return products;
        }
    }
}
