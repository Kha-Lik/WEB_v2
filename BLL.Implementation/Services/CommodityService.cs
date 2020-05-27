using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Abstract;
using BLL.Models;
using DAL.Abstract;
using DAL.Entities;

namespace BLL.Implementation.Services
{
    public class CommodityService : ICommodityService

    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public CommodityService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public IEnumerable<CommodityModel> GetAll()
        {
            var commodities = _unit.CommodityRepository.GetAll();
            var commodityModels = _mapper.Map<IEnumerable<CommodityModel>>(commodities);
            return commodityModels;
        }

        public CommodityModel GetById(int id)
        {
            var commodity = _unit.CommodityRepository.GetByIdAsync(id).Result;
            return _mapper.Map<CommodityModel>(commodity);
        }


        public IEnumerable<CommodityModel> GetByIdCollection(params int[] idCollection)
        {
            var commodities = new List<Commodity>();
            foreach (var id in idCollection) commodities.Add(_unit.CommodityRepository.GetByIdAsync(id).Result);

            return _mapper.Map<IEnumerable<CommodityModel>>(commodities);
        }

        public CommodityModel Search(string name)
        {
            var commodities = _unit.CommodityRepository.GetAll();
            var commodity = commodities.FirstOrDefault(x => x.Name.Equals(name));
            var commodityModel = _mapper.Map<CommodityModel>(commodity);
            return commodityModel;
        }

        public IEnumerable<CommodityModel> Search(int orderNum)
        {
            var orders = _unit.PurchaseOrderRepository.GetAll();
            var order = orders.FirstOrDefault(x => x.Number == orderNum);
            var commodities = order.Commodities;
            var commodityModels = _mapper.Map<IEnumerable<CommodityModel>>(commodities);
            return commodityModels;
        }

        public IEnumerable<CommodityModel> SearchByShopId(int shopId)
        {
            var shopEntity = _unit.ShopRepository.GetByIdAsync(shopId).Result;
            var commoditiesInShops = _unit.CommodityInShopRepository.GetAll();
            var commoditiesInShop = commoditiesInShops.Where(x => x.Shop.Equals(shopEntity)).Select(x => x.Commodity);
            var commodities = _mapper.Map<IEnumerable<CommodityModel>>(commoditiesInShop);
            return commodities;
        }

        public IEnumerable<CommodityModel> SearchByWarehouseId(int warehouseId)
        {
            var warehouseEntity = _unit.WarehouseRepository.GetByIdAsync(warehouseId).Result;
            var commoditiesInWarehouses = _unit.CommodityInWarehoseRepository.GetAll();
            var commoditiesInWarehouse = commoditiesInWarehouses.Where(x => x.Warehouse.Equals(warehouseEntity))
                .Select(x => x.Commodity);
            var commodities = _mapper.Map<IEnumerable<CommodityModel>>(commoditiesInWarehouse);
            return commodities;
        }
    }
}