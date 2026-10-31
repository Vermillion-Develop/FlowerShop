using Microsoft.EntityFrameworkCore;

namespace FlowerShopBackground.Data
{
    public class AppDataContext: DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            //public DbSet<>
        }
    }
}
