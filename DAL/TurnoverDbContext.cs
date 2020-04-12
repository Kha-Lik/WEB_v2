using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TurnoverDbContext : DbContext
    {
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<CommodityInShop> CommoditiesInShop { get; set; }
        public DbSet<CommodityInWarehouse> CommoditiesInWarehouse { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<OrdersCommodities> PurchaseElements { get; set; }

        public TurnoverDbContext(DbContextOptions<TurnoverDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}