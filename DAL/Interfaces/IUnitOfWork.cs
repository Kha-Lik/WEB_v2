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
        public IRepository<CommodityInWarehouse> CommodityInWarehose { get; }
        public IRepository<PurchaseOrder> PurchaseOrderRepository { get; }
        public IRepository<PurchaseElement> PurchaseElementRepository { get; }

        Task Save();
    }
}