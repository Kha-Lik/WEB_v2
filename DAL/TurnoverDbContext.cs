using System;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public sealed class TurnoverDbContext : DbContext
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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var shop1 = new Shop()
            {
                Id = 1, Name = "ATB"
            };
            var shop2 = new Shop()
            {
                Id = 2, Name = "Rozetka"
            };
            
            var warehouse1 = new Warehouse()
            {
                Id = 1, Name = "First warehouse"
            };
            var warehouse2 = new Warehouse()
            {
                Id = 2, Name = "Second warehouse"
            };
            
            var commodity1 = new Commodity()
            {
                Id = 1, Name = "Bread", Price = 20
            };
            var commodity2 = new Commodity()
            {
                Id = 2, Name = "Wine", Price = 150
            };
            
            var commInShop1 = new CommodityInShop()
            {
                Id = 1, CommodityId = 1, ShopId = 1
            };
            var commInShop2 = new CommodityInShop()
            {
                Id = 2, CommodityId = 2, ShopId = 2
            };
            
            var commInWarehouse1 = new  CommodityInWarehouse()
            {
                Id = 1,  CommodityId = 2, WarehouseId = 1
            };
            var commInWarehouse2 = new CommodityInWarehouse()
            {
                Id = 2,  CommodityId = 1, WarehouseId = 2
            };
            
            var order1 = new PurchaseOrder()
            {
                Id = 1, Date = DateTime.Now, ShopId = 1, Name = "Sample order", Number = 1001,
            };
            var order2 = new PurchaseOrder()
            {
                Id = 2, Date = DateTime.Now, ShopId = 2, Name = "Second sample order", Number = 10011001,
            };
            
            var ordComm1 = new OrdersCommodities()
            {
                Id = 1, CommodityId = 1,  PurchaseOrderId = 1
            };
            var ordComm2 = new OrdersCommodities()
            {
                Id = 2, CommodityId = 2,  PurchaseOrderId = 1
            };
            var ordComm3 = new OrdersCommodities()
            {
                Id = 3,  CommodityId = 1, PurchaseOrderId = 2
            };
            var ordComm4 = new OrdersCommodities()
            {
                Id = 4,  CommodityId = 2,  PurchaseOrderId = 2
            };

            modelBuilder.Entity<Shop>().HasData(shop1, shop2);
            modelBuilder.Entity<Warehouse>().HasData(warehouse1, warehouse2);
            modelBuilder.Entity<PurchaseOrder>().HasData(order1, order2);
            modelBuilder.Entity<Commodity>().HasData(commodity1, commodity2);
            modelBuilder.Entity<CommodityInShop>().HasData(commInShop1, commInShop2);
            modelBuilder.Entity<CommodityInWarehouse>().HasData(commInWarehouse1, commInWarehouse2);
            modelBuilder.Entity<OrdersCommodities>().HasData(ordComm1, ordComm2, ordComm3, ordComm4);
        }
    }
}