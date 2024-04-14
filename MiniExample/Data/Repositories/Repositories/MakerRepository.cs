using Microsoft.EntityFrameworkCore;
using MiniExample.Data.Repositories.Interfaces;
using MiniExample.Data.Datacontext;
using MiniExample.Data.Entities;

namespace MiniExample.Data.Repositories.Repositories
{
    public class MakerRepository : GenericRepository<MakerEntity>, IMakerRepository
    {
        public MakerRepository(MiniContext _context) : base(_context)
        {
            this.Context = _context;
        }

        public async  Task<IQueryable<MakerEntity>> GetAll1()
        {
            IQueryable<MakerEntity> query = Table;
            return query;
        }
        public async  Task<IEnumerable<MakerEntity>> GetAll2()
        {
            IEnumerable<MakerEntity> query = Table;
            return query;
        }
    }
}
