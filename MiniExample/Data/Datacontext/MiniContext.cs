using Microsoft.EntityFrameworkCore;
using MiniExample.Data.Entities;

namespace MiniExample.Data.Datacontext
{
    public class MiniContext : DbContext
    {
        

            public DbSet<MakerEntity> Makers { get; set; } = null!;
            public DbSet<ProductEntity> Products { get; set; } = null!;
           

            public MiniContext(DbContextOptions<MiniContext> options) : base(options)
            {
            }
            


        
    }
}
