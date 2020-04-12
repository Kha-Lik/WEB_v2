using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CommodityService : ICommodityService

    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

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

        public IEnumerable<CommodityModel> Search(ShopModel shop)
        {
            var shopEntity = _mapper.Map<Shop>(shop);
            var commoditiesInShops = _unit.CommodityInShopRepository.GetAll();
            var commoditiesInShop = commoditiesInShops.Where(x => x.Shop.Equals(shopEntity)).Select(x => x.Commodity);
            var commodities = _mapper.Map<IEnumerable<CommodityModel>>(commoditiesInShop);
            return commodities;
        }

        public IEnumerable<CommodityModel> Search(WarehouseModel warehouse)
        {
            var warehouseEntity = _mapper.Map<Warehouse>(warehouse);
            var commoditiesInWarehouses = _unit.CommodityInWarehoseRepository.GetAll();
            var commoditiesInWarehouse = commoditiesInWarehouses.Where(x => x.Warehouse.Equals(warehouseEntity)).Select(x => x.Commodity);
            var commodities = _mapper.Map<IEnumerable<CommodityModel>>(commoditiesInWarehouse);
            return commodities;
        }
    }
}