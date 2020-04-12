using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Commodity> CommodityRepository { get; }
        public IRepository<Shop> ShopRepository { get; }
        public IRepository<Warehouse> WarehouseRepository { get; }
        public IRepository<CommodityInShop> CommodityInShopRepository { get; }
        public IRepository<CommodityInWarehouse> CommodityInWarehoseRepository { get; }
        public IRepository<PurchaseOrder> PurchaseOrderRepository { get; }
        public IRepository<OrdersCommodities> PurchaseElementRepository { get; }

        Task Save();
    }
}