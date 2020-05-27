using System.Threading.Tasks;
using DAL.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TurnoverDbContext _context;

        public UnitOfWork(TurnoverDbContext context,
            IRepository<Commodity> commodityRepository,
            IRepository<Shop> shopRepository,
            IRepository<Warehouse> warehouseRepository,
            IRepository<CommodityInShop> commodityInShopRepository,
            IRepository<CommodityInWarehouse> commodityInWarehoseRepository,
            IRepository<PurchaseOrder> purchaseOrderRepository,
            IRepository<OrdersCommodities> purchaseElementRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            CommodityRepository = commodityRepository;
            ShopRepository = shopRepository;
            WarehouseRepository = warehouseRepository;
            CommodityInShopRepository = commodityInShopRepository;
            CommodityInWarehoseRepository = commodityInWarehoseRepository;
            PurchaseOrderRepository = purchaseOrderRepository;
            PurchaseElementRepository = purchaseElementRepository;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IRepository<Commodity> CommodityRepository { get; }
        public IRepository<Shop> ShopRepository { get; }
        public IRepository<Warehouse> WarehouseRepository { get; }
        public IRepository<CommodityInShop> CommodityInShopRepository { get; }
        public IRepository<CommodityInWarehouse> CommodityInWarehoseRepository { get; }
        public IRepository<PurchaseOrder> PurchaseOrderRepository { get; }
        public IRepository<OrdersCommodities> PurchaseElementRepository { get; }
        public UserManager<User> UserManager { get;  }
        public SignInManager<User> SignInManager { get;  }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}