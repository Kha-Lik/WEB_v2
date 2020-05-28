using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using BLL.Models;
using DAL.Abstract;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICommodityService _commodityService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public OrderService(IUnitOfWork unit, IMapper mapper, ICommodityService commodityService)
        {
            _unit = unit;
            _mapper = mapper;
            _commodityService = commodityService;
        }

        public IEnumerable<PurchaseOrderModel> GetAll()
        {
            var orders = _unit.PurchaseOrderRepository.GetAll()
                .Include(p => p.Commodities)
                .ThenInclude(oc => oc.Commodity);
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

        public async Task MakeOrderAsync(OrderPropertiesContainer orderPropertiesContainer)
        {
            var commodities = _commodityService.GetByIdCollection(orderPropertiesContainer.CommodityIds);
            var purchaseOrderModel = new PurchaseOrderModel
            {
                Commodities = commodities,
                Date = DateTime.Now.Date,
                Name = orderPropertiesContainer.Name,
                Number = orderPropertiesContainer.Number,
                ShopId = orderPropertiesContainer.ShopId,
                WarehouseId = orderPropertiesContainer.WarehouseId
            };
            var order = _mapper.Map<PurchaseOrder>(purchaseOrderModel);
            await _unit.PurchaseOrderRepository.CreateAsync(order);
            await _unit.Save();
        }
    }
}