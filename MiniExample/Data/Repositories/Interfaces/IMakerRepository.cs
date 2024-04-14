using MiniExample.Data.Entities;

namespace MiniExample.Data.Repositories.Interfaces
{
    public interface IMakerRepository : IGenericRepository<MakerEntity>
    {
         public Task<IQueryable<MakerEntity>> GetAll1();
        public Task<IEnumerable<MakerEntity>> GetAll2();
    }
}
