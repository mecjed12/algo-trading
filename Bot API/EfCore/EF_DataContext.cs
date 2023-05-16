using Bot_API.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Bot_API.DataContext
{
    public class EF_DataContext : DbContext, IEF_DataContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) :
            base(options)
        { }


        //For Tutorial
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        //  For the Main project
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<HistoricalDataList> HistoricalData { get; set;}
        public DbSet<TradingPair> TradingPairs { get; set; } 

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           return  await base.SaveChangesAsync(cancellationToken);
        }
    }
}
