using MiniExample.Data.Entities;

namespace MiniExample.Data.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<ProductEntity>
    {

        public  Task<IEnumerable<ProductEntity>> GetProducts();
    }
}
