using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public OrderService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public IEnumerable<PurchaseOrderModel> GetAll()
        {
            var orders = _unit.PurchaseOrderRepository.GetAll();
            var orderModels = _mapper.Map<IEnumerable<PurchaseOrderModel>>(orders);
            return orderModels;
        }

        public PurchaseOrderModel Search(string name)
        {
            var orders = _unit.PurchaseOrderRepository.GetAll();
            var order = orders.FirstOrDefault(x => x.Name.Equals(name));
            var orderModel = _mapper.Map<PurchaseOrderModel>(order);
            return orderModel;
        }

        public IEnumerable<PurchaseOrderModel> SearchByDate(DateTime date)
        {
            var orders = _unit.PurchaseOrderRepository.GetAll();
            orders = orders.Where(x => x.Date.Date == date.Date);
            var orderModels = _mapper.Map<IEnumerable<PurchaseOrderModel>>(orders);
            return orderModels;
        }

        public IEnumerable<PurchaseOrderModel> SearchByQuantity(int quantity)
        {
            var orders = _unit.PurchaseOrderRepository.GetAll();
            orders = orders.Where(x => x.Commodities.Count() == quantity);
            var orderModels = _mapper.Map<IEnumerable<PurchaseOrderModel>>(orders);
            return orderModels;
        }

        public async Task MakeOrder(IEnumerable<CommodityModel> commodities, ShopModel shop, string name, int number)
        {
            var orderModel = new PurchaseOrderModel()
            {
                Name = name, Number = number, Commodities = commodities, Date = DateTime.Now, Shop = shop
            };
            var order = _mapper.Map<PurchaseOrder>(orderModel);
            await _unit.PurchaseOrderRepository.Create(order);
            await _unit.Save();
        }

        public async Task MakeOrder(IEnumerable<CommodityModel> commodities, WarehouseModel warehouse, string name, int number)
        {
            var orderModel = new PurchaseOrderModel()
            {
                Name = name, Number = number, Commodities = commodities, Date = DateTime.Now, Warehouse = warehouse
            };
            var order = _mapper.Map<PurchaseOrder>(orderModel);
            await _unit.PurchaseOrderRepository.Create(order);
            await _unit.Save();
        }
    }
}