using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<PurchaseOrderModel>> GetAll();
        Task<PurchaseOrderModel> Search(string name);
        Task<IEnumerable<PurchaseOrderModel>> Search(DateTime date);
        Task<IEnumerable<PurchaseOrderModel>> Search(int quantity);
        Task MakeOrder(IEnumerable<CommodityModel> commoditis, ShopModel shop);
        Task MakeOrder(IEnumerable<CommodityModel> commoditis, WarehouseModel warehouse);
    }
}