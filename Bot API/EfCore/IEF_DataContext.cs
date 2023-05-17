using Microsoft.EntityFrameworkCore;

namespace Bot_API.EfCore
{
    public interface IEF_DataContext 
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<HistoricalDataList> HistoricalDataList { get; set; }
        public DbSet<TradingPair> TradingPairs { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
